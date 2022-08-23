using Scheduler.Api.Helpers;

namespace Scheduler.Api.CompaniesOpeningHours
{
    public class CompanyOpeningHours : BaseModel
    {
        public Guid CompanyId { get; set; }
        public int DayOfTheWeek { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}
