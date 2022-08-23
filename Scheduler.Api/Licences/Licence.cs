using MediatR;
using Scheduler.Api.Data;

namespace Scheduler.Api.Licences
{
    public class Licence : BaseModel, IRequest<Result<Guid>>
    {
        public string? Name { get; set; }
    }
}
