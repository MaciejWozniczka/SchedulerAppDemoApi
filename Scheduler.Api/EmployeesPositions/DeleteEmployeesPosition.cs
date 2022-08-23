using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.EmployeesPositions
{
    [ApiController]
    public class DeleteEmployeesPosition : Controller
    {
        private readonly IMediator _mediator;

        public DeleteEmployeesPosition(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("/api/DeleteEmployeesPosition/{id}")]
        public async Task<IActionResult> Delete(Guid id) => await _mediator.Send(new DeleteEmployeesPositionCommand(id)).Process();

        public class DeleteEmployeesPositionCommand : IRequest<Result>
        {
            public DeleteEmployeesPositionCommand(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class DeleteEmployeesPositionCommandHandler : IRequestHandler<DeleteEmployeesPositionCommand, Result>
        {
            private readonly IEmployeesPositionRepository _repository;

            public DeleteEmployeesPositionCommandHandler(IEmployeesPositionRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(DeleteEmployeesPositionCommand request, CancellationToken cancellationToken)
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