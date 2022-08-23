using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.UserCompanies
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserCompanies : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetUserCompanies(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/Tenant/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetUserCompaniesQuery(id)).Process();

        public class GetUserCompaniesQuery : IRequest<Result<UserCompany>>
        {
            public GetUserCompaniesQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetUserCompaniesQueryHandler : IRequestHandler<GetUserCompaniesQuery, Result<UserCompany>>
        {
            private readonly DataContext _db;

            public GetUserCompaniesQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<UserCompany>> Handle(GetUserCompaniesQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.UserCompanies
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<UserCompany>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}