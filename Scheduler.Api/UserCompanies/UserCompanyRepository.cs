using Scheduler.Api.Data;

namespace Scheduler.Api.UserCompanies
{
    public class UserCompanyRepository : Repository<UserCompany>, IUserCompanyRepository
    {
        public UserCompanyRepository(DataContext db) : base(db)
        {
        }
    }

    public interface IUserCompanyRepository
    {
        Task<UserCompany> Create(UserCompany model, CancellationToken cancellationToken);
        Task<UserCompany> Update(UserCompany model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<UserCompany> GetById(Guid id, CancellationToken cancellationToken);
    }
}