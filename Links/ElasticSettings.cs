using System;

namespace WordCounter.Common
{
    public class ElasticSettings : ConnectSettings
    {
        public ElasticSettings()
        {
            DependencyName = "elasticsearch";
            ConnectTimeout = TimeSpan.FromMinutes(5);
            RetryDelay = TimeSpan.FromSeconds(20);
        }

        public string HostName { get; set; }

        public int Port { get; set; }

        public string IndexName { get; set; }
    }
}
