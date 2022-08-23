using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.EmployeesPositions
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetEmployeesPosition : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetEmployeesPosition(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/Tenant/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetEmployeesPositionQuery(id)).Process();

        public class GetEmployeesPositionQuery : IRequest<Result<EmployeesPosition>>
        {
            public GetEmployeesPositionQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetEmployeesPositionQueryHandler : IRequestHandler<GetEmployeesPositionQuery, Result<EmployeesPosition>>
        {
            private readonly DataContext _db;

            public GetEmployeesPositionQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<EmployeesPosition>> Handle(GetEmployeesPositionQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.EmployeesPositions
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<EmployeesPosition>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}