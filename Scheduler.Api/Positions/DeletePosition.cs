using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Positions
{
    [ApiController]
    public class DeletePosition : Controller
    {
        private readonly IMediator _mediator;

        public DeletePosition(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("/api/DeletePosition/{id}")]
        public async Task<IActionResult> Delete(Guid id) => await _mediator.Send(new DeletePositionCommand(id)).Process();

        public class DeletePositionCommand : IRequest<Result>
        {
            public DeletePositionCommand(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, Result>
        {
            private readonly IPositionRepository _repository;

            public DeletePositionCommandHandler(IPositionRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
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