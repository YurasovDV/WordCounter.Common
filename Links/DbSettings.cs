using System;

namespace WordCounter.Common
{
    public class DbSettings : ConnectSettings
    {
        public DbSettings()
        {
            DependencyName = "db";
            ConnectTimeout = TimeSpan.FromMinutes(5);
            RetryDelay = TimeSpan.FromSeconds(2);
        }

        public string HostName { get; set; }

        public int Port { get; set; }

        public string DatabaseName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public ConnectionFactory ConnectionFactory { get; set; }

        // too little time
        public bool IsPostgres { get; set; }
    }
}
