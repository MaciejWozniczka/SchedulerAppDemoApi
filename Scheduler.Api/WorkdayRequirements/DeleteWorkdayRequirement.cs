using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.WorkdayRequirements
{
    [ApiController]
    public class DeleteWorkdayRequirement : Controller
    {
        private readonly IMediator _mediator;

        public DeleteWorkdayRequirement(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("/api/InputData/{id}")]
        public async Task<IActionResult> Delete(Guid id) => await _mediator.Send(new DeleteWorkdayRequirementCommand(id)).Process();

        public class DeleteWorkdayRequirementCommand : IRequest<Result>
        {
            public DeleteWorkdayRequirementCommand(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class DeleteWorkdayRequirementCommandHandler : IRequestHandler<DeleteWorkdayRequirementCommand, Result>
        {
            private readonly IWorkdayRequirementRepository _repository;

            public DeleteWorkdayRequirementCommandHandler(IWorkdayRequirementRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(DeleteWorkdayRequirementCommand request, CancellationToken cancellationToken)
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