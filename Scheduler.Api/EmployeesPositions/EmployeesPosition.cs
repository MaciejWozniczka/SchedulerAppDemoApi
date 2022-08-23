using Scheduler.Api.Helpers;

namespace Scheduler.Api.EmployeesPositions
{
    public class EmployeesPosition : BaseModel
    {
        public Guid EmployeeId { get; set; }
        public Guid PositionId { get; set; }

    }
}
