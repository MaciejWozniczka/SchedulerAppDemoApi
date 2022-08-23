using Scheduler.Api.Data;

namespace Scheduler.Api.Companies
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(DataContext db) : base(db)
        {
        }
    }

    public interface ICompanyRepository
    {
        Task<Company> Create(Company model, CancellationToken cancellationToken);
        Task<Company> Update(Company model, CancellationToken cancellationToken);
        Task<bool> Delete(Company model, CancellationToken cancellationToken);
        Task<Company> GetById(Guid id, CancellationToken cancellationToken);
    }
}