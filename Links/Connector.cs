using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Data;
using System.Threading;

namespace WordCounter.Common
{
    public class Connector
    {
        public IConnection ConnectToQueue(ILogger logger, QueueSettings settings)
        {
            RabbitMQ.Client.ConnectionFactory factory = new RabbitMQ.Client.ConnectionFactory()
            {
                HostName = settings.HostName,
                Port = settings.Port,
                UserName = settings.UserName,
                Password = settings.Password,
            };

            var end = DateTime.UtcNow.Add(settings.TimeoutToConnect);
            Exception toLog = null;
            while (DateTime.UtcNow < end)
            {
                try
                {
                    var connection = factory.CreateConnection();
                    return connection;
                }
                catch (Exception ex)
                {
                    toLog = ex;
                    logger.LogWarning($"connect to queue failed: {ex.Message}");
                }
                Thread.Sleep((int)TimeSpan.FromSeconds(2).TotalMilliseconds);
            }
            if (toLog != null)
            {
                throw toLog;
            }
            throw new Exception("no retries left");
        }

        public void EnsureDbIsUp(ILogger _logger, DbSettings settings)
        {
            var end = DateTime.UtcNow.Add(settings.TimeoutToConnect);
            Exception toLog = null;
            bool success = false;
            while (DateTime.UtcNow < end && !success)
            {
                try
                {
                    IDbConnection connection = ConnectionFactory.GetConnection(settings);
                    connection.Open();
                    // execute select 1?
                    connection.Close();
                    success = true;
                    break;
                }
                catch (Exception ex)
                {
                    toLog = ex;
                    _logger.LogWarning($"connect to db failed: {ex.Message}");
                }
                if (!success)
                {
                    Thread.Sleep((int)settings.TimeoutToConnect.TotalMilliseconds);
                }
            }
            if (toLog != null)
            {
                throw toLog;
            }
            if (!success)
            {
                throw new Exception("no retries left");
            }
        }
    }
}
