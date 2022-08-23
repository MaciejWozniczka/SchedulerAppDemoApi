using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        [HttpGet("/api/Tenant/{id}")]
        public async Task<IActionResult> Get(Guid id) => await _mediator.Send(new GetCompanyQuery(id)).Process();

        public class GetCompanyQuery : IRequest<Result<CompanyDto>>
        {
            public GetCompanyQuery(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }
        public class CompanyDto
        {
            public Guid Id { get; set; }
            public bool IsActive { get; set; }
            public string? Name { get; set; }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile() => CreateMap<Company, CompanyDto>();
        }

        public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, Result<CompanyDto>>
        {
            private readonly DataContext _db;
            private readonly IMapper _mapper;

            public GetCompanyQueryHandler(DataContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<Result<CompanyDto>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.Companies
                    .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (result == null)
                {
                    return Result.NotFound<CompanyDto>(request.Id);
                }

                return Result.Ok(result);
            }
        }
    }
}