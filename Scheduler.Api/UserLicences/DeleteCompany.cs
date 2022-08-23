using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.UserLicences
{
    [ApiController]
    public class DeleteUserLicence : Controller
    {
        private readonly IMediator _mediator;

        public DeleteUserLicence(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("/api/DeleteUserLicence/{id}")]
        public async Task<IActionResult> Delete(Guid id) => await _mediator.Send(new DeleteUserLicenceCommand(id)).Process();

        public class DeleteUserLicenceCommand : IRequest<Result>
        {
            public DeleteUserLicenceCommand(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class DeleteUserLicenceCommandHandler : IRequestHandler<DeleteUserLicenceCommand, Result>
        {
            private readonly IUserLicenceRepository _repository;

            public DeleteUserLicenceCommandHandler(IUserLicenceRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(DeleteUserLicenceCommand request, CancellationToken cancellationToken)
            {
                var result = await _repository.Delete(request.Id, cancellationToken);

                if (result)
                {
                    return Result.Ok();
                }

                return Result.NotFound(request.Id);
            }
        }
    }
}