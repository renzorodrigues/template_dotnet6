using Braboz.Core.Helpers;
using MediatR;

namespace Braboz.Core.Handlers.Interfaces
{
    public interface IQuery<TResult> : IRequest<Result<TResult>>
    {
    }
}
