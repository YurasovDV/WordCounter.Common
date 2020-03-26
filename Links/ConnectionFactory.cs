using Microsoft.Data.SqlClient;
using System.Data;
using Npgsql;

namespace WordCounter.Common
{
    public class ConnectionFactory
    {
        public static string GetConnectionString(DbSettings settings)
        {
            string connectionString;
            if (settings.IsPostgres)
            {
                var builder = new NpgsqlConnectionStringBuilder();
                builder.Host = settings.HostName;
                builder.Port = settings.Port;
                builder.Username = settings.UserName;
                builder.Password = settings.Password;
                builder.Database = settings.DatabaseName;
                connectionString = builder.ConnectionString;
            }
            else
            {
                var sqlServerBuilder = new SqlConnectionStringBuilder();
                sqlServerBuilder.DataSource = settings.HostName;
                sqlServerBuilder.UserID = settings.UserName;
                sqlServerBuilder.Password = settings.Password;
                sqlServerBuilder.InitialCatalog = settings.DatabaseName;
                connectionString = sqlServerBuilder.ConnectionString;
            }
            return connectionString;
        }

        public static IDbConnection GetConnection(DbSettings settings)
        {
            IDbConnection conn;
            var connectionString = GetConnectionString(settings);
            if (settings.IsPostgres)
            {
                conn = new NpgsqlConnection(connectionString);
            }
            else
            {
                conn = new SqlConnection(connectionString);
            }
            return conn;
        }
    }
}