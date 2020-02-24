using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using RabbitConnectionFactory = RabbitMQ.Client.ConnectionFactory;

namespace WordCounter.Common
{
    public class Connector
    {
        public IConnection ConnectToQueue(ILogger logger, QueueSettings settings)
        {
            Func<IConnection> connect = () =>
            {
                var connection = new RabbitConnectionFactory()
                {
                    HostName = settings.HostName,
                    Port = settings.Port,
                    UserName = settings.UserName,
                    Password = settings.Password,
                }.CreateConnection();
                return connection;
            };

            IConnection connection = EnsureIsUp(logger, settings, connect);
            return connection;
        }

        public void EnsureDbIsUp(ILogger _logger, DbSettings settings)
        {
            Func<bool> connect = () =>
            {
                using (IDbConnection connection = ConnectionFactory.GetConnection(settings))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT 1";
                        using (var reader = command.ExecuteReader())
                        {
                            return true;
                        }
                    }
                }
            };

            EnsureIsUp(_logger, settings, connect);
        }

        public T EnsureIsUp<T>(ILogger logger, ConnectSettings settings, Func<T> ping)
        {
            var end = DateTime.UtcNow.Add(settings.ConnectTimeout);
            Exception toLog = null;
            T result = default;
            while (DateTime.UtcNow < end && IsDefault(result))
            {
                try
                {
                    result = ping();
                }
                catch (Exception ex)
                {
                    toLog = ex;
                    logger?.LogWarning($"connect to {settings.DependencyName} failed: {ex.Message}");
                }
                if (EqualityComparer<T>.Default.Equals(result, default))
                {
                    Thread.Sleep((int)settings.RetryDelay.TotalMilliseconds);
                }
            }
            if (toLog != null && IsDefault(result))
            {
                throw toLog;
            }
            if (IsDefault(result))
            {
                throw new Exception($"FATAL: connect to {settings.DependencyName} failed: no retries left");
            }
            return result;
        }

        private static bool IsDefault<T>(T obj) 
        {
            return EqualityComparer<T>.Default.Equals(obj, default);
        }
    }
}
