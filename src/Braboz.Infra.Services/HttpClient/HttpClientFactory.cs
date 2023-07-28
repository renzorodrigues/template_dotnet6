using System.Text.Json;
using Braboz.Application.Services.Interfaces.HttpClient;

namespace Braboz.Infra.Services.HttpClient
{
    public class HttpClientFactory : IHttpClient
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HttpClientFactory(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IList<T>> CreateClient<T>(string baseAddress, string requestUri)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            var client = this.httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            try
            {
                var response = await client.GetStringAsync(requestUri);

                var serializedResponse = JsonSerializer.Deserialize<IList<T>>(response, options);

                if (serializedResponse != null)
                    return serializedResponse;

                return default!;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
