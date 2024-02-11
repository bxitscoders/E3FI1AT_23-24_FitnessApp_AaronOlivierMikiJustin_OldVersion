using Npgsql;

namespace Model.Database
{
    public class DatabaseService
    {
        public string _connectionString;

        public DatabaseService()
        {
        }

        public DatabaseService(string connectionString)
        {
            _connectionString = BuildConnectionString();
        }

        public string BuildConnectionString()
        {
            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder
            {
                Host = "surus.db.elephantsql.com",
                Port = 5432,
                Database = "pcrerpgl",
                Username = "pcrerpgl",
                Password = "kyjKyeMkVKy4y-S544YNQ2CR-JZj3xF9"
            };
            return builder.ConnectionString;
        }
    }
}
