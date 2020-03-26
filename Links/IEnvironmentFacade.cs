namespace WordCounter.Common
{
    public interface IEnvironmentFacade
    {
        DbSettings BuildDbSettings();
        QueueSettings BuildQueueSettings();

        ElasticSettings BuildElasticSettings();
    }
}