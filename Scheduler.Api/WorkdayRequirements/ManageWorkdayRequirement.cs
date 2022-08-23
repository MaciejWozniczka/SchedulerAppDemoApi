using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.WorkdayRequirements
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageWorkdayRequirement : ControllerBase
    {
        private readonly IMediator mediator;

        public ManageWorkdayRequirement(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("/api/Tenant")]
        public async Task<IActionResult> Post(WorkdayRequirement command)
        {
            return await mediator.Send(command).Process();
        }

        public class ManageWorkdayRequirementQueryHandler : IRequestHandler<WorkdayRequirement, Result<Guid>>
        {
            private readonly IWorkdayRequirementRepository repository;

            public ManageWorkdayRequirementQueryHandler(IWorkdayRequirementRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<Guid>> Handle(WorkdayRequirement request, CancellationToken cancellationToken)
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