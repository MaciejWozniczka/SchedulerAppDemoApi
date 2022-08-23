using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Positions
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllPositions : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAllPositions(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/Tenant/{id}")]
        public async Task<IActionResult> Get() => await _mediator.Send(new GetAllPositionsQuery()).Process();

        public class GetAllPositionsQuery : IRequest<Result<List<Position>>>
        {
        }

        public class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQuery, Result<List<Position>>>
        {
            private readonly DataContext _db;

            public GetAllPositionsQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<List<Position>>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.Positions
                    .ToListAsync(cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<List<Position>>();
                }

                return Result.Ok(result);
            }
        }
    }
}