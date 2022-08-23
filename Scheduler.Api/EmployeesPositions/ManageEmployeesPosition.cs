using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.EmployeesPositions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageEmployeesPosition : ControllerBase
    {
        private readonly IMediator mediator;

        public ManageEmployeesPosition(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("/api/Tenant")]
        public async Task<IActionResult> Post(EmployeesPosition command)
        {
            return await mediator.Send(command).Process();
        }

        public class ManageEmployeesPositionQueryHandler : IRequestHandler<EmployeesPosition, Result<Guid>>
        {
            private readonly IEmployeesPositionRepository repository;

            public ManageEmployeesPositionQueryHandler(IEmployeesPositionRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<Guid>> Handle(EmployeesPosition request, CancellationToken cancellationToken)
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