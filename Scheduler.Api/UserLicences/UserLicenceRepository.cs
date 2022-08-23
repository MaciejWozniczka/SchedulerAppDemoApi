using Scheduler.Api.Data;

namespace Scheduler.Api.UserLicences
{
    public class UserLicenceRepository : Repository<UserLicence>, IUserLicenceRepository
    {
        public UserLicenceRepository(DataContext db) : base(db)
        {
        }
    }

    public interface IUserLicenceRepository
    {
        Task<UserLicence> Create(UserLicence model, CancellationToken cancellationToken);
        Task<UserLicence> Update(UserLicence model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<UserLicence> GetById(Guid id, CancellationToken cancellationToken);
    }
}