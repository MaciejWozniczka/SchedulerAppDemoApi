using MediatR;
using Scheduler.Api.Data;

namespace Scheduler.Api.EmployeesPositions
{
    public class EmployeesPosition : BaseModel, IRequest<Result<Guid>>
    {
        public Guid EmployeeId { get; set; }
        public Guid PositionId { get; set; }
    }
}
