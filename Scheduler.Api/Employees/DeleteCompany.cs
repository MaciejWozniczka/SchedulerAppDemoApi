using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Employees
{
    [ApiController]
    public class DeleteEmployees : Controller
    {
        private readonly IMediator _mediator;

        public DeleteEmployees(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("/api/InputData/{id}")]
        public async Task<IActionResult> Delete(Guid id) => await _mediator.Send(new DeleteEmployeesCommand(id)).Process();

        public class DeleteEmployeesCommand : IRequest<Result>
        {
            public DeleteEmployeesCommand(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class DeleteEmployeesCommandHandler : IRequestHandler<DeleteEmployeesCommand, Result>
        {
            private readonly IEmployeeRepository _repository;

            public DeleteEmployeesCommandHandler(IEmployeeRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(DeleteEmployeesCommand request, CancellationToken cancellationToken)
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