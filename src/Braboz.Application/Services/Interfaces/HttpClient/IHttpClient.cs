namespace Braboz.Application.Services.Interfaces.HttpClient
{
    public interface IHttpClient
    {
        Task<IList<T>> CreateClient<T>(string baseAddress, string requestUri);
    }
}
