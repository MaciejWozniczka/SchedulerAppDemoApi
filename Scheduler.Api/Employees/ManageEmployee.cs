using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageEmployee : ControllerBase
    {
        private readonly IMediator mediator;

        public ManageEmployee(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("/api/ManageEmployee")]
        public async Task<IActionResult> Post(Employee command)
        {
            return await mediator.Send(command).Process();
        }

        public class ManageEmployeeQueryHandler : IRequestHandler<Employee, Result<Guid>>
        {
            private readonly IEmployeeRepository repository;

            public ManageEmployeeQueryHandler(IEmployeeRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<Guid>> Handle(Employee request, CancellationToken cancellationToken)
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