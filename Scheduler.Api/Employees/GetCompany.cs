using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetEmployee : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetEmployee(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/Tenant/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetEmployeeQuery(id)).Process();

        public class GetEmployeeQuery : IRequest<Result<Employee>>
        {
            public GetEmployeeQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Result<Employee>>
        {
            private readonly DataContext _db;

            public GetEmployeeQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<Employee>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.Employees
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<Employee>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}