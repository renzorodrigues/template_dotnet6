using System.Text.Json.Serialization;
using Braboz.Core.Handlers.Interfaces;

namespace Braboz.Core.Handlers
{
    public abstract class Command<TResult> : ICommand<TResult>
    {
        public Guid RequestId { get; set; }
    }
}
