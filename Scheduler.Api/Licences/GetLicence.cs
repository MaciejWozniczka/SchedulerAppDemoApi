using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Licences
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetLicence : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetLicence(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/Tenant/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetLicenceQuery(id)).Process();

        public class GetLicenceQuery : IRequest<Result<Licence>>
        {
            public GetLicenceQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class GetLicenceQueryHandler : IRequestHandler<GetLicenceQuery, Result<Licence>>
        {
            private readonly DataContext _db;

            public GetLicenceQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<Licence>> Handle(GetLicenceQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.Licences
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<Licence>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}