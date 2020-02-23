namespace WordCounter.Common
{
    public class Constants
    {
        public static class Environment
        {
            public static class Queue
            {
                public const string RabbitMqHost = "RabbitMqHost";
                public const string RabbitMqPort = "RabbitMqPort";
                public const string RabbitMqUser = "RabbitMqUser";
                public const string RabbitMqPass = "RabbitMqPass";
            }

            public static class Database
            {
                public const string Host = "DbHost";
                public const string Port = "DbPort";
                public const string User = "DbUser";
                public const string Pass = "DbPass";
                public const string Db = "Db";
            }
        }


        public const string ArticlesExchange = "articles";
        public const string RoutingKey = "";
        public const string HelloWorldMessage = "060ca0f6-f111-4e45-be12-7d62832bf328";
    }
}
