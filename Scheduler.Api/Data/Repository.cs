using Microsoft.EntityFrameworkCore;

namespace Scheduler.Api.Data
{
    public class Repository<T> : IRepository where T : BaseModel, new()
    {
        private readonly DataContext db;
        private readonly DbSet<T> dbSet;

        public Repository(DataContext db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();
        }

        public async Task<T> Create(T model, CancellationToken cancellationToken)
        {
            await dbSet.AddAsync(model, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            return model;
        }

        public async Task<T> Update(T model, CancellationToken cancellationToken)
        {
            await db.SaveChangesAsync(cancellationToken);

            return model;
        }

        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            var model = await GetById(id, cancellationToken);

            model.IsActive = false;

            var result = await db.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<T> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await dbSet.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

            if (result == null)
                return new T();
            else
                return result;
        }
    }

    public interface IRepository
    {
    }
}