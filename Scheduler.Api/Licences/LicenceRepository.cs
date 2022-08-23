using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;

namespace Scheduler.Api.Licences
{
    public class LicenceRepository : Repository<Licence>, ILicenceRepository
    {
        private readonly DataContext db;
        private readonly DbSet<Licence> dbSet;
        public LicenceRepository(DataContext db) : base(db)
        {
            this.db = db;
            this.dbSet = db.Set<Licence>();
        }

        public async Task<List<Licence>> GetAll(CancellationToken cancellationToken)
        {
            return await dbSet
                .ToListAsync(cancellationToken);
        }
    }

    public interface ILicenceRepository
    {
        Task<Licence> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<Licence>> GetAll(CancellationToken cancellationToken);
    }
}