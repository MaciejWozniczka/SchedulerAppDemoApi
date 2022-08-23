using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Positions
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetPosition : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetPosition(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/Tenant/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetPositionQuery(id)).Process();

        public class GetPositionQuery : IRequest<Result<Position>>
        {
            public GetPositionQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetPositionQueryHandler : IRequestHandler<GetPositionQuery, Result<Position>>
        {
            private readonly DataContext _db;

            public GetPositionQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<Position>> Handle(GetPositionQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.Positions
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<Position>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}