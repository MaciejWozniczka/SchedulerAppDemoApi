using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;

namespace Scheduler.Api.EmployeesPositions
{
    public class EmployeesPositionRepository : Repository<EmployeesPosition>, IEmployeesPositionRepository
    {
        private readonly DataContext db;
        private readonly DbSet<EmployeesPosition> dbSet;
        public EmployeesPositionRepository(DataContext db) : base(db)
        {
            this.db = db;
            this.dbSet = db.Set<EmployeesPosition>();
        }

        public async Task<List<EmployeesPosition>> GetAllByEmployeeId(Guid empoloyeeId, CancellationToken cancellationToken)
        {
            return await dbSet
                .Where(c => c.EmployeeId == empoloyeeId)
                .ToListAsync(cancellationToken);
        }
    }

    public interface IEmployeesPositionRepository
    {
        Task<EmployeesPosition> Create(EmployeesPosition model, CancellationToken cancellationToken);
        Task<EmployeesPosition> Update(EmployeesPosition model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<EmployeesPosition> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<EmployeesPosition>> GetAllByEmployeeId(Guid empoloyeeId, CancellationToken cancellationToken);
    }
}