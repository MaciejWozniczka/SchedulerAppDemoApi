using MediatR;
using Scheduler.Api.Data;

namespace Scheduler.Api.Companies
{
    public class Company : BaseModel, IRequest<Result<Guid>>
    {
        public string? Name { get; set; }
    }
}
