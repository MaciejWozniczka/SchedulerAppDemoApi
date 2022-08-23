using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.UserCompanies
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserCompanies : ControllerBase
    {
        private readonly IMediator mediator;

        public ManageUserCompanies(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("/api/ManageUserCompanies")]
        public async Task<IActionResult> Post(UserCompany command)
        {
            return await mediator.Send(command).Process();
        }

        public class ManageUserCompaniesQueryHandler : IRequestHandler<UserCompany, Result<Guid>>
        {
            private readonly IUserCompanyRepository repository;

            public ManageUserCompaniesQueryHandler(IUserCompanyRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<Guid>> Handle(UserCompany request, CancellationToken cancellationToken)
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