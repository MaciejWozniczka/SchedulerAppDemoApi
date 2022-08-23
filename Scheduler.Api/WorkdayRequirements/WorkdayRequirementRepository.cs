using Scheduler.Api.Data;

namespace Scheduler.Api.WorkdayRequirements
{
    public class WorkdayRequirementRepository : Repository<WorkdayRequirement>, IWorkdayRequirementRepository
    {
        public WorkdayRequirementRepository(DataContext db) : base(db)
        {
        }
    }

    public interface IWorkdayRequirementRepository
    {
        Task<WorkdayRequirement> Create(WorkdayRequirement model, CancellationToken cancellationToken);
        Task<WorkdayRequirement> Update(WorkdayRequirement model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<WorkdayRequirement> GetById(Guid id, CancellationToken cancellationToken);
    }
}