using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;

namespace Scheduler.Api.Positions
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        private readonly DataContext db;
        private readonly DbSet<Position> dbSet;
        public PositionRepository(DataContext db) : base(db)
        {
            this.db = db;
            this.dbSet = db.Set<Position>();
        }

        public async Task<List<Position>> GetAll(CancellationToken cancellationToken)
        {
            return await dbSet
                .ToListAsync(cancellationToken);
        }
    }

    public interface IPositionRepository
    {
        Task<Position> Create(Position model, CancellationToken cancellationToken);
        Task<Position> Update(Position model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<Position> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<Position>> GetAll(CancellationToken cancellationToken);
    }
}