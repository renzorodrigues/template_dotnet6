using Braboz.Application.Models.User;
using Braboz.Application.Products.CQS.Queries;
using Braboz.Application.Services.Interfaces.HttpClient;
using Braboz.Core.Helpers;
using Braboz.Core.Settings;
using MediatR;
using Microsoft.Extensions.Options;

namespace Braboz.Application.Products.Handlers.User
{
    public class UserHandler :
        IRequestHandler<GetAllUsersQuery, Result<IEnumerable<GetAllUsersResponse>>>
    {
        private readonly IHttpClient httpClient;
        private readonly HttpClientSettings httpClientSettings;

        public UserHandler(IHttpClient httpClient, IOptions<HttpClientSettings> options)
        {
            this.httpClient = httpClient;
            this.httpClientSettings = options.Value;
        }

        public async Task<Result<IEnumerable<GetAllUsersResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await this.httpClient
                .CreateClient<GetAllUsersResponse>(this.httpClientSettings.BaseAddress!, this.httpClientSettings.RequestUri!);

            return new Result<IEnumerable<GetAllUsersResponse>>(result);
        }
    }
}
