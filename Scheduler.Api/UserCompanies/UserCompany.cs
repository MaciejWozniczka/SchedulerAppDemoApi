using Scheduler.Api.Data;

namespace Scheduler.Api.UserCompanies
{
    public class UserCompany : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
