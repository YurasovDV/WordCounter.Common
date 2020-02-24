using System;

namespace WordCounter.Common
{
    public class QueueSettings : ConnectSettings
    {
        public QueueSettings()
        {
           DependencyName = "queue";
           ConnectTimeout = TimeSpan.FromMinutes(5);
           RetryDelay = TimeSpan.FromSeconds(2);
        }

        public string HostName { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
