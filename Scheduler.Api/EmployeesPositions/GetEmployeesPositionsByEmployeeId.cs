using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.EmployeesPositions
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetEmployeesPositionsByEmployeeId : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetEmployeesPositionsByEmployeeId(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/Tenant/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetEmployeesPositionsByEmployeeIdQuery(id)).Process();

        public class GetEmployeesPositionsByEmployeeIdQuery : IRequest<Result<List<EmployeesPosition>>>
        {
            public GetEmployeesPositionsByEmployeeIdQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetEmployeesPositionsByEmployeeIdQueryHandler : IRequestHandler<GetEmployeesPositionsByEmployeeIdQuery, Result<List<EmployeesPosition>>>
        {
            private readonly DataContext _db;

            public GetEmployeesPositionsByEmployeeIdQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<List<EmployeesPosition>>> Handle(GetEmployeesPositionsByEmployeeIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.EmployeesPositions
                    .Where(e => e.EmployeeId == request.Id)
                    .ToListAsync(cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<List<EmployeesPosition>>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}