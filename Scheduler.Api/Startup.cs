using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scheduler.Api.Authentication;
using Scheduler.Api.Companies;
using Scheduler.Api.CompaniesOpeningHours;
using Scheduler.Api.Data;
using Scheduler.Api.Employees;
using Scheduler.Api.EmployeesPositions;
using Scheduler.Api.Licences;
using Scheduler.Api.Positions;
using Scheduler.Api.UserCompanies;
using Scheduler.Api.UserLicences;
using Scheduler.Api.WorkdayRequirements;
using System.Text;

namespace Scheduler.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DataContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["Authentication:Issuer"],
                        ValidAudience = Configuration["Authentication:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                    };
                });

            services.AddAuthorization(options =>
            { options.AddPolicy("Admin", policy => policy.RequireRole("admin")); });

            services.AddAuthorization(options =>
            { options.AddPolicy("ClientAdmin", policy => policy.RequireRole("clientadmin")); });

            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyOpeningHoursRepository, CompanyOpeningHoursRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeesPositionRepository, EmployeesPositionRepository>();
            services.AddScoped<ILicenceRepository, LicenceRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IUserCompanyRepository, UserCompanyRepository>();
            services.AddScoped<IUserLicenceRepository, UserLicenceRepository>();
            services.AddScoped<IWorkdayRequirementRepository, WorkdayRequirementRepository>();

            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchedulerApp", Version = "v1" });
            });
        }

        public void Configure(UserManager<User> userManager, IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Seeder.Seed(userManager).Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchedulerApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}