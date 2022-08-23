using Scheduler.Api.Data;

namespace Scheduler.Api.Licences
{
    public class LicenceRepository : Repository<Licence>, ILicenceRepository
    {
        public LicenceRepository(DataContext db) : base(db)
        {
        }
    }

    public interface ILicenceRepository
    {
        Task<Licence> GetById(Guid id, CancellationToken cancellationToken);
    }
}