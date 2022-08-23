using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.CompaniesOpeningHours
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCompanyOpeningHours : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetCompanyOpeningHours(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/GetCompanyOpeningHours/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetCompanyOpeningHoursQuery(id)).Process();

        public class GetCompanyOpeningHoursQuery : IRequest<Result<List<CompanyOpeningHours>>>
        {
            public Guid Id { get; set; }
            public GetCompanyOpeningHoursQuery(Guid id)
            {
                Id = id;
            }
        }

        public class GetCompanyOpeningHoursQueryHandler : IRequestHandler<GetCompanyOpeningHoursQuery, Result<List<CompanyOpeningHours>>>
        {
            private readonly DataContext _db;

            public GetCompanyOpeningHoursQueryHandler(DataContext db)
            {
                _db = db;
            }

            public async Task<Result<List<CompanyOpeningHours>>> Handle(GetCompanyOpeningHoursQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.CompaniesOpeningHours
                    .Where(c => c.CompanyId == request.Id)
                    .ToListAsync(cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<List<CompanyOpeningHours>>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}