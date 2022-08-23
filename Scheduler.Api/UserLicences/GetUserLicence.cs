using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.UserLicences
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserLicence : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetUserLicence(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/GetUserLicence/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetUserLicenceQuery(id)).Process();

        public class GetUserLicenceQuery : IRequest<Result<UserLicence>>
        {
            public GetUserLicenceQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetUserLicenceQueryHandler : IRequestHandler<GetUserLicenceQuery, Result<UserLicence>>
        {
            private readonly DataContext _db;

            public GetUserLicenceQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<UserLicence>> Handle(GetUserLicenceQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.UserLicences
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<UserLicence>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}