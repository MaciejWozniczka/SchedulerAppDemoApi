using MediatR;
using Scheduler.Api.Data;

namespace Scheduler.Api.UserCompanies
{
    public class UserCompany : BaseModel, IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
