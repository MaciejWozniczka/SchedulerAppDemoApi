using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetEmployeesByCompanyId : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetEmployeesByCompanyId(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/Tenant/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetEmployeesByCompanyIdQuery(id)).Process();

        public class GetEmployeesByCompanyIdQuery : IRequest<Result<List<Employee>>>
        {
            public GetEmployeesByCompanyIdQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetEmployeesByCompanyIdQueryHandler : IRequestHandler<GetEmployeesByCompanyIdQuery, Result<List<Employee>>>
        {
            private readonly DataContext _db;

            public GetEmployeesByCompanyIdQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<List<Employee>>> Handle(GetEmployeesByCompanyIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.Employees
                    .Where(e => e.CompanyId == request.Id)
                    .ToListAsync(cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<List<Employee>>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}