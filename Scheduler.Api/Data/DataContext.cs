using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Authentication;
using Scheduler.Api.Companies;
using Scheduler.Api.Employees;
using Scheduler.Api.EmployeesPositions;
using Scheduler.Api.Licences;
using Scheduler.Api.Positions;
using Scheduler.Api.UserCompanies;
using Scheduler.Api.UserLicences;
using Scheduler.Api.WorkdayRequirements;

namespace Scheduler.Api.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Licence>? Licences { get; set; }
        public DbSet<UserLicence>? UserLicences { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<UserCompany>? UserCompanies { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Position>? Positions { get; set; }
        public DbSet<EmployeesPosition>? EmployeesPositions { get; set; }
        public DbSet<WorkdayRequirement>? WorkdayRequirements { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
            modelBuilder.Entity<Licence>().HasKey("Id");
            modelBuilder.Entity<UserLicence>().HasKey("Id");
            modelBuilder.Entity<Company>().HasKey("Id");
            modelBuilder.Entity<UserCompany>().HasKey("Id");
            modelBuilder.Entity<Employee>().HasKey("Id");
            modelBuilder.Entity<Position>().HasKey("Id");
            modelBuilder.Entity<EmployeesPosition>().HasKey("Id");
            modelBuilder.Entity<WorkdayRequirement>().HasKey("Id");
        }
    }
}