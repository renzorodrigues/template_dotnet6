namespace Braboz.Core.Helpers
{
    public class Result<T> : CustomResult
    {
        public T Data { get; }

        public Result(T data)
        {
            this.Data = data;
        }
    }
}
