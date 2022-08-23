using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.UserLicences
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserLicence : ControllerBase
    {
        private readonly IMediator mediator;

        public ManageUserLicence(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("/api/Tenant")]
        public async Task<IActionResult> Post(UserLicence command)
        {
            return await mediator.Send(command).Process();
        }

        public class ManageUserLicenceQueryHandler : IRequestHandler<UserLicence, Result<Guid>>
        {
            private readonly IUserLicenceRepository repository;

            public ManageUserLicenceQueryHandler(IUserLicenceRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<Guid>> Handle(UserLicence request, CancellationToken cancellationToken)
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