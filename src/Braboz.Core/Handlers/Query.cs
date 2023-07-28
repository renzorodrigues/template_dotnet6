using System.Text.Json.Serialization;
using Braboz.Core.Handlers.Interfaces;

namespace Braboz.Core.Handlers
{
    public abstract class Query<TResult> : IQuery<TResult>
    {
        public Guid RequestId { get; set; }
    }
}
