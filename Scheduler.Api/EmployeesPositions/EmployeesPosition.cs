using Scheduler.Api.Data;

namespace Scheduler.Api.EmployeesPositions
{
    public class EmployeesPosition : BaseModel
    {
        public Guid EmployeeId { get; set; }
        public Guid PositionId { get; set; }

    }
}
