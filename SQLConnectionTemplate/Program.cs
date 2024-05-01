using MySqlConnector;
using System.Security;

namespace SQLConnectionTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string server, username, password, database;
            Console.Write("Enter server IP: ");
            server = Console.ReadLine();
            Console.Write("Enter username: ");
            username = Console.ReadLine();
            password = getPasswordEntry();
            Console.Write("Enter database: ");
            database = Console.ReadLine();
            MySqlConnection conn = con(server, username, password, database);

            conn.Open();

        }
        static MySqlConnection con(string server, string user, string password, string database)
        {
            string connectDetails = $"server={server};uid={user};password={password};database={database}";
            MySqlConnection con = new MySqlConnection(connectDetails);
            return con;
        }
       static string getPasswordEntry()
        {
            Console.Write("Enter password: ");
            ConsoleKey key;
            string password = string.Empty;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }
    }
}
