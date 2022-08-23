using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

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
        public async Task<IActionResult> Post(Company command)
        {
            return await mediator.Send(command).Process();
        }

        public class ManageCompanyQueryHandler : IRequestHandler<Company, Result<Guid>>
        {
            private readonly ICompanyRepository repository;

            public ManageCompanyQueryHandler(ICompanyRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<Guid>> Handle(Company request, CancellationToken cancellationToken)
            {
                bool isAdding = request.Id == Guid.Empty;

                if (isAdding)
                {
                    await repository.Create(request, cancellationToken);
                }
                else
                {
                    await repository.Update(request, cancellationToken);
                }

                return Result.Ok(request.Id);
            }
        }
    }
}