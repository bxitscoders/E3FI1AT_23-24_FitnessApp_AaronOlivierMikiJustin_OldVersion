using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class DBConnector
    {
        private readonly string connectionString;


        public DBConnector(string host, string port, string database, string username, string password)
        {
            // Verbindungszeichenfolge erstellen
            connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";
        }

        public void Connect()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Erfolgreich mit der Datenbank verbunden.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Verbinden mit der Datenbank: {ex.Message}");
            }
        }
    }
}
