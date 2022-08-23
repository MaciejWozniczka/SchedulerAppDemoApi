using Scheduler.Api.Helpers;

namespace Scheduler.Api.Companies
{
    public class Company : BaseModel
    {
        public string? Name { get; set; }
        public int DayOfTheWeek { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}
