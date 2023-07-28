namespace Braboz.Core.Helpers
{
    public class Error
    {
        public string Message { get; }

        public Error(string errorMessage)
        {
            this.Message = errorMessage;
        }
    }
}
