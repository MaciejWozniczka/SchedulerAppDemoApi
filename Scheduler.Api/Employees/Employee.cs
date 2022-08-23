using Scheduler.Api.Helpers;

namespace Scheduler.Api.Employees
{
    public class Employee : BaseModel
    {
        public string? Name { get; set; }
        public Guid CompanyId { get; set; }
        public int MonthlyWorkingHours { get; set; }
        public int DailyWorkingHours { get; set; }
        public int MaxDailyWorkingHours { get; set; }
        public string? PreferredTimeOfDay { get; set; }
    }
}
