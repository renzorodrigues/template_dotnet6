using Braboz.Core.Helpers;
using MediatR;

namespace Braboz.Core.Handlers.Interfaces
{
    public interface ICommand<TResult> : IRequest<Result<TResult>>
    {
    }
}
