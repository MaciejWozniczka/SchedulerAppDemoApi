using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.UserCompanies
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserCompaniesByUserId : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetUserCompaniesByUserId(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/Tenant/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetUserCompaniesByUserIdQuery(id)).Process();

        public class GetUserCompaniesByUserIdQuery : IRequest<Result<List<UserCompany>>>
        {
            public GetUserCompaniesByUserIdQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetUserCompaniesByUserIdQueryHandler : IRequestHandler<GetUserCompaniesByUserIdQuery, Result<List<UserCompany>>>
        {
            private readonly DataContext _db;

            public GetUserCompaniesByUserIdQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<List<UserCompany>>> Handle(GetUserCompaniesByUserIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.UserCompanies
                    .Where(e => e.UserId == request.Id)
                    .ToListAsync(cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<List<UserCompany>>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}