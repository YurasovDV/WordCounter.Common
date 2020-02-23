using System;

namespace WordCounter.Common
{
    public class DbSettings
    {
        public string HostName { get; set; }

        public int Port { get; set; }

        public string DatabaseName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public TimeSpan TimeoutToConnect { get; set; }

        public ConnectionFactory ConnectionFactory { get; set; }

        // too little time
        public bool IsPostgres { get; set; }
    }
}
