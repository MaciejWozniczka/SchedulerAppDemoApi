using Scheduler.Api.Data;

namespace Scheduler.Api.Positions
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(DataContext db) : base(db)
        {
        }
    }

    public interface IPositionRepository
    {
        Task<Position> Create(Position model, CancellationToken cancellationToken);
        Task<Position> Update(Position model, CancellationToken cancellationToken);
        Task<bool> Delete(Position model, CancellationToken cancellationToken);
        Task<Position> GetById(Guid id, CancellationToken cancellationToken);
    }
}