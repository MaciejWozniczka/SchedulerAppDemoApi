using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;

namespace Scheduler.Api.Employees
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly DataContext db;
        private readonly DbSet<Employee> dbSet;
        public EmployeeRepository(DataContext db) : base(db)
        {
            this.db = db;
            this.dbSet = db.Set<Employee>();
        }

        public async Task<List<Employee>> GetAllByCompanyId(Guid companyId, CancellationToken cancellationToken)
        {
            return await dbSet
                .Where(c => c.CompanyId == companyId)
                .ToListAsync(cancellationToken);
        }
    }

    public interface IEmployeeRepository
    {
        Task<Employee> Create(Employee model, CancellationToken cancellationToken);
        Task<Employee> Update(Employee model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<Employee> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<Employee>> GetAllByCompanyId(Guid id, CancellationToken cancellationToken);
    }
}