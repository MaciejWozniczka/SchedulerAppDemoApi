using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;
using System.Text.Json.Serialization;

namespace Scheduler.Api.Companies
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageCompany : ControllerBase
    {
        private readonly IMediator mediator;

        public ManageCompany(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("/api/Tenant")]
        public async Task<IActionResult> Post(ManageCompanyCommand command)
        {
            return await mediator.Send(command).Process();
        }

        public class ManageCompanyCommand : IRequest<Result<Guid>>
        {
            [JsonIgnore]
            public Guid Id { get; set; }
            public bool IsActive { get; set; }
            public string? Name { get; set; }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<ManageCompanyCommand, Company>();
            }
        }
        public class ManageCompanyQueryHandler : IRequestHandler<ManageCompanyCommand, Result<Guid>>
        {
            private readonly IMapper mapper;
            private readonly ICompanyRepository repository;

            public ManageCompanyQueryHandler(IMapper mapper, ICompanyRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            public async Task<Result<Guid>> Handle(ManageCompanyCommand request, CancellationToken cancellationToken)
            {
                Company tenant;
                bool isAdding = request.Id == Guid.Empty;
                if (isAdding)
                {
                    tenant = new Company();
                }
                else
                {
                    tenant = await repository.GetById(request.Id, cancellationToken);
                    if (tenant == null)
                    {
                        return Result.NotFound<Guid>(request.Id);
                    }
                }
                tenant = mapper.Map(request, tenant);

                if (isAdding)
                {
                    await repository.Create(tenant, cancellationToken);
                }
                else
                {
                    await repository.Update(tenant, cancellationToken);
                }

                return Result.Ok(tenant.Id);
            }
        }
    }
}