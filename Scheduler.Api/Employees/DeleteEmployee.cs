using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Employees
{
    [ApiController]
    public class DeleteEmployee : Controller
    {
        private readonly IMediator _mediator;

        public DeleteEmployee(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("/api/DeleteEmployee/{id}")]
        public async Task<IActionResult> Delete(Guid id) => await _mediator.Send(new DeleteEmployeeCommand(id)).Process();

        public class DeleteEmployeeCommand : IRequest<Result>
        {
            public DeleteEmployeeCommand(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Result>
        {
            private readonly IEmployeeRepository _repository;

            public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var result = await _repository.Delete(request.Id, cancellationToken);

                if (result)
                {
                    return Result.Ok();
                }

                return Result.NotFound(request.Id);
            }
        }
    }
}