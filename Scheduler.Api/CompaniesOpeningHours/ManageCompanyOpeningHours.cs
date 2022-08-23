using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.CompaniesOpeningHours
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageCompanyOpeningHours : ControllerBase
    {
        private readonly IMediator mediator;

        public ManageCompanyOpeningHours(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("/api/Tenant")]
        public async Task<IActionResult> Post(CompanyOpeningHours command)
        {
            return await mediator.Send(command).Process();
        }

        public class ManageCompanyOpeningHoursQueryHandler : IRequestHandler<CompanyOpeningHours, Result<Guid>>
        {
            private readonly ICompanyOpeningHoursRepository repository;

            public ManageCompanyOpeningHoursQueryHandler(ICompanyOpeningHoursRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<Guid>> Handle(CompanyOpeningHours request, CancellationToken cancellationToken)
            {
                bool isAdding = request.Id == Guid.Empty;

                if (isAdding)
                {
                    await repository.Create(request, cancellationToken);
                }
                else
                {
                    await repository.Update(request, cancellationToken);
                }

                return Result.Ok(request.Id);
            }
        }
    }
}