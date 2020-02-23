using Microsoft.Data.SqlClient;
using System.Data;
using Npgsql;

namespace WordCounter.Common
{
    public class ConnectionFactory
    {
        public static IDbConnection GetConnection(DbSettings settings)
        {
            IDbConnection conn;
            if (settings.IsPostgres)
            {
                var builder = new NpgsqlConnectionStringBuilder();
                builder.Host = settings.HostName;
                builder.Port = settings.Port;
                builder.Username = settings.UserName;
                builder.Password = settings.Password;
                conn = new NpgsqlConnection(builder.ConnectionString);
            }
            else
            {
                var sqlServerBuilder = new SqlConnectionStringBuilder();
                sqlServerBuilder.DataSource = settings.HostName;
                sqlServerBuilder.UserID = settings.UserName;
                sqlServerBuilder.Password = settings.Password;
                conn = new SqlConnection(sqlServerBuilder.ConnectionString);
            }
            return conn;
        }
    }
}