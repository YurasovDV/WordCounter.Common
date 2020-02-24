using System;

namespace WordCounter.Common
{
    public class ConnectSettings
    {
        public string DependencyName { get; set; }

        public TimeSpan ConnectTimeout { get; set; }

        public TimeSpan RetryDelay { get; set; }
    }
}
