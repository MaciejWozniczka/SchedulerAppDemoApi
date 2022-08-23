using Scheduler.Api.Data;

namespace Scheduler.Api.CompaniesOpeningHours
{
    public class CompanyOpeningHoursRepository : Repository<CompanyOpeningHours>, ICompanyOpeningHoursRepository
    {
        public CompanyOpeningHoursRepository(DataContext db) : base(db)
        {
        }
    }

    public interface ICompanyOpeningHoursRepository
    {
        Task<CompanyOpeningHours> Create(CompanyOpeningHours model, CancellationToken cancellationToken);
        Task<CompanyOpeningHours> Update(CompanyOpeningHours model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<CompanyOpeningHours> GetById(Guid id, CancellationToken cancellationToken);
    }
}