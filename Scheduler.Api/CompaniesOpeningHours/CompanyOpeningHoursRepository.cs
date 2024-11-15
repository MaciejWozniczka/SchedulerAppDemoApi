﻿using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;

namespace Scheduler.Api.CompaniesOpeningHours
{
    public class CompanyOpeningHoursRepository : Repository<CompanyOpeningHours>, ICompanyOpeningHoursRepository
    {
        private readonly DataContext db;
        private readonly DbSet<CompanyOpeningHours> dbSet;
        public CompanyOpeningHoursRepository(DataContext db) : base(db)
        {
            this.db = db;
            this.dbSet = db.Set<CompanyOpeningHours>();
        }

        public async Task<List<CompanyOpeningHours>> GetAllByCompanyId(Guid companyId, CancellationToken cancellationToken)
        {
            var result = await dbSet
                .Where(c => c.CompanyId == companyId)
                .ToListAsync(cancellationToken);

            if (result == null)
                return new();
            else
                return result;
        }
    }

    public interface ICompanyOpeningHoursRepository
    {
        Task<CompanyOpeningHours> Create(CompanyOpeningHours model, CancellationToken cancellationToken);
        Task<CompanyOpeningHours> Update(CompanyOpeningHours model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<List<CompanyOpeningHours>> GetAllByCompanyId(Guid id, CancellationToken cancellationToken);
    }
}