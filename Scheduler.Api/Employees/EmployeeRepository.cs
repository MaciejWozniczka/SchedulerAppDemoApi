using Scheduler.Api.Data;

namespace Scheduler.Api.Employees
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext db) : base(db)
        {
        }
    }

    public interface IEmployeeRepository
    {
        Task<Employee> Create(Employee model, CancellationToken cancellationToken);
        Task<Employee> Update(Employee model, CancellationToken cancellationToken);
        Task<bool> Delete(Employee model, CancellationToken cancellationToken);
        Task<Employee> GetById(Guid id, CancellationToken cancellationToken);
    }
}