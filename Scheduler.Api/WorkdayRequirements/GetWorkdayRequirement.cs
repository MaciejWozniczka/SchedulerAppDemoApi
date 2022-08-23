using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.WorkdayRequirements
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetWorkdayRequirement : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetWorkdayRequirement(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/GetWorkdayRequirement/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetWorkdayRequirementQuery(id)).Process();

        public class GetWorkdayRequirementQuery : IRequest<Result<WorkdayRequirement>>
        {
            public GetWorkdayRequirementQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetWorkdayRequirementQueryHandler : IRequestHandler<GetWorkdayRequirementQuery, Result<WorkdayRequirement>>
        {
            private readonly DataContext _db;

            public GetWorkdayRequirementQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<WorkdayRequirement>> Handle(GetWorkdayRequirementQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.WorkdayRequirements
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<WorkdayRequirement>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}