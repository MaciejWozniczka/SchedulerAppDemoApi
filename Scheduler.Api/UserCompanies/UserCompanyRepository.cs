using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;

namespace Scheduler.Api.UserCompanies
{
    public class UserCompanyRepository : Repository<UserCompany>, IUserCompanyRepository
    {
        private readonly DataContext db;
        private readonly DbSet<UserCompany> dbSet;
        public UserCompanyRepository(DataContext db) : base(db)
        {
            this.db = db;
            this.dbSet = db.Set<UserCompany>();
        }

        public async Task<List<UserCompany>> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
        {
            return await dbSet
                .Where(c => c.UserId == userId)
                .ToListAsync(cancellationToken);
        }
    }

    public interface IUserCompanyRepository
    {
        Task<UserCompany> Create(UserCompany model, CancellationToken cancellationToken);
        Task<UserCompany> Update(UserCompany model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<UserCompany> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<UserCompany>> GetAllByUserId(Guid userId, CancellationToken cancellationToken);
    }
}