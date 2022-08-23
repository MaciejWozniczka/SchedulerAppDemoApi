using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.WorkdayRequirements
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetWorkdayRequirementsByCompanyId : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetWorkdayRequirementsByCompanyId(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/Tenant/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetWorkdayRequirementsByCompanyIdQuery(id)).Process();

        public class GetWorkdayRequirementsByCompanyIdQuery : IRequest<Result<List<WorkdayRequirement>>>
        {
            public GetWorkdayRequirementsByCompanyIdQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetWorkdayRequirementsByCompanyIdQueryHandler : IRequestHandler<GetWorkdayRequirementsByCompanyIdQuery, Result<List<WorkdayRequirement>>>
        {
            private readonly DataContext _db;

            public GetWorkdayRequirementsByCompanyIdQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<List<WorkdayRequirement>>> Handle(GetWorkdayRequirementsByCompanyIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.WorkdayRequirements
                    .Where(e => e.CompanyId == request.Id)
                    .ToListAsync(cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<List<WorkdayRequirement>>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}