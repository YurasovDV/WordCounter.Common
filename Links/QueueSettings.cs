using System;

namespace WordCounter.Common
{
    public class QueueSettings
    {
        public string HostName { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public TimeSpan TimeoutToConnect { get; set; }
    }
}
