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
        Task<Licence> Create(Licence model, CancellationToken cancellationToken);
        Task<Licence> Update(Licence model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<Licence> GetById(Guid id, CancellationToken cancellationToken);
    }
}