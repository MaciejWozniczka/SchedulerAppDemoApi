using Scheduler.Api.Helpers;

namespace Scheduler.Api.UserLicences
{
    public class UserLicence : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid LicenceId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
