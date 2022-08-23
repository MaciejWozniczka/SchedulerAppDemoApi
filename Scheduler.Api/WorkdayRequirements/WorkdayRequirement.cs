using Scheduler.Api.Helpers;

namespace Scheduler.Api.WorkdayRequirements
{
    public class WorkdayRequirement : BaseModel
    {
        public Guid CompanyId { get; set; }
        public Guid PositionId { get; set; }
        public int Quantity { get; set; }
        public int DayOfTheWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
