using Braboz.Application.Models.User;
using Braboz.Core.Handlers;

namespace Braboz.Application.Products.CQS.Queries
{
    public class GetAllUsersQuery : Query<IEnumerable<GetAllUsersResponse>>
    {
        public GetAllUsersQuery()
        {
            RequestId = Guid.NewGuid();
        }
    }
}
