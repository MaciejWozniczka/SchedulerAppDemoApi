using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Companies
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCompany : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetCompany(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/GetCompany/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetCompanyQuery(id)).Process();

        public class GetCompanyQuery : IRequest<Result<Company>>
        {
            public GetCompanyQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, Result<Company>>
        {
            private readonly DataContext _db;

            public GetCompanyQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<Company>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.Companies
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<Company>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}