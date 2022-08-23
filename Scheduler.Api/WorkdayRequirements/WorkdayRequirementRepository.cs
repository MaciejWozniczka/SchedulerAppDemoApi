using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;

namespace Scheduler.Api.WorkdayRequirements
{
    public class WorkdayRequirementRepository : Repository<WorkdayRequirement>, IWorkdayRequirementRepository
    {
        private readonly DataContext db;
        private readonly DbSet<WorkdayRequirement> dbSet;
        public WorkdayRequirementRepository(DataContext db) : base(db)
        {
            this.db = db;
            this.dbSet = db.Set<WorkdayRequirement>();
        }

        public async Task<List<WorkdayRequirement>> GetAllByCompanyId(Guid companyId, CancellationToken cancellationToken)
        {
            return await dbSet
                .Where(c => c.CompanyId == companyId)
                .ToListAsync(cancellationToken);
        }
    }

    public interface IWorkdayRequirementRepository
    {
        Task<WorkdayRequirement> Create(WorkdayRequirement model, CancellationToken cancellationToken);
        Task<WorkdayRequirement> Update(WorkdayRequirement model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<WorkdayRequirement> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<WorkdayRequirement>> GetAllByCompanyId(Guid companyId, CancellationToken cancellationToken);
    }
}