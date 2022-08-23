using Scheduler.Api.Data;

namespace Scheduler.Api.EmployeesPositions
{
    public class EmployeesPositionRepository : Repository<EmployeesPosition>, IEmployeesPositionRepository
    {
        public EmployeesPositionRepository(DataContext db) : base(db)
        {
        }
    }

    public interface IEmployeesPositionRepository
    {
        Task<EmployeesPosition> Create(EmployeesPosition model, CancellationToken cancellationToken);
        Task<EmployeesPosition> Update(EmployeesPosition model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<EmployeesPosition> GetById(Guid id, CancellationToken cancellationToken);
    }
}