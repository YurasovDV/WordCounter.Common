using System;

namespace WordCounter.Common
{
    public class EnvironmentFacade : IEnvironmentFacade
    {
        public QueueSettings BuildQueueSettings()
        {
            var settings = new QueueSettings();
            settings.HostName = GetEnvironmentOrThrow(Constants.Environment.Queue.RabbitMqHost);
            settings.Port = GetEnvironmentAsIntOrThrow(Constants.Environment.Queue.RabbitMqPort);
            settings.UserName = GetEnvironmentOrThrow(Constants.Environment.Queue.RabbitMqUser);
            settings.Password = GetEnvironmentOrThrow(Constants.Environment.Queue.RabbitMqPass);
            return settings;
        }

        public DbSettings BuildDbSettings()
        {
            var settings = new DbSettings();
            settings.HostName = GetEnvironmentOrThrow(Constants.Environment.Database.Host);
            settings.Port = GetEnvironmentAsIntOrThrow(Constants.Environment.Database.Port);
            settings.UserName = GetEnvironmentOrThrow(Constants.Environment.Database.User);
            settings.Password = GetEnvironmentOrThrow(Constants.Environment.Database.Pass);
            settings.DatabaseName = GetEnvironmentOrThrow(Constants.Environment.Database.Db);
            settings.IsPostgres = true;
            settings.ConnectionFactory = new ConnectionFactory();

            return settings;
        }

        private static string GetEnvironmentOrThrow(string variableName)
        {
            var value = Environment.GetEnvironmentVariable(variableName);
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException($"empty value for {variableName}");
            }
            return value;
        }

        private static int GetEnvironmentAsIntOrThrow(string variableName)
        {
            var value = GetEnvironmentOrThrow(variableName);
            if (int.TryParse(value, out int res))
            {
                return res;
            }
            throw new InvalidOperationException($"Invalid value(integer expected) for {variableName}: {value}");
        }
    }
}
