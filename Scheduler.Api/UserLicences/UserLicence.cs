using MediatR;
using Scheduler.Api.Data;

namespace Scheduler.Api.UserLicences
{
    public class UserLicence : BaseModel, IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public Guid LicenceId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
