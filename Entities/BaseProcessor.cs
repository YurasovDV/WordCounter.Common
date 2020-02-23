
namespace WordCounter.Common
{
    public abstract class BaseProcessor<T>
    {
        public abstract OperationResult<T> Process(BusinessMessage message);
    }
}
