using MediatR;
using Scheduler.Api.Data;

namespace Scheduler.Api.CompaniesOpeningHours
{
    public class CompanyOpeningHours : BaseModel, IRequest<Result<Guid>>
    {
        public Guid CompanyId { get; set; }
        public int DayOfTheWeek { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}
