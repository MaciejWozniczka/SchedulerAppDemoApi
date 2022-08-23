using MediatR;
using Scheduler.Api.Data;

namespace Scheduler.Api.Positions
{
    public class Position : BaseModel, IRequest<Result<Guid>>
    {
        public string? Name { get; set; }
    }
}
