using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Licences
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllLicences : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAllLicences(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/GetAllLicences")]
        public async Task<IActionResult> Get() => await _mediator.Send(new GetAllLicencesQuery()).Process();

        public class GetAllLicencesQuery : IRequest<Result<List<Licence>>>
        {
        }

        public class GetAllLicencesQueryHandler : IRequestHandler<GetAllLicencesQuery, Result<List<Licence>>>
        {
            private readonly DataContext _db;

            public GetAllLicencesQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<List<Licence>>> Handle(GetAllLicencesQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.Licences
                    .ToListAsync(cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<List<Licence>>();
                }

                return Result.Ok(result);
            }
        }
    }
}