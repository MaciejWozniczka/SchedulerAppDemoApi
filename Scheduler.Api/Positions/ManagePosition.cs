using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Positions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagePosition : ControllerBase
    {
        private readonly IMediator mediator;

        public ManagePosition(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("/api/ManagePosition")]
        public async Task<IActionResult> Post(Position command)
        {
            return await mediator.Send(command).Process();
        }

        public class ManagePositionQueryHandler : IRequestHandler<Position, Result<Guid>>
        {
            private readonly IPositionRepository repository;

            public ManagePositionQueryHandler(IPositionRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<Guid>> Handle(Position request, CancellationToken cancellationToken)
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