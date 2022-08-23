using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.UserCompanies
{
    [ApiController]
    public class DeleteUserCompanies : Controller
    {
        private readonly IMediator _mediator;

        public DeleteUserCompanies(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("/api/DeleteUserCompanies/{id}")]
        public async Task<IActionResult> Delete(Guid id) => await _mediator.Send(new DeleteUserCompaniesCommand(id)).Process();

        public class DeleteUserCompaniesCommand : IRequest<Result>
        {
            public DeleteUserCompaniesCommand(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class DeleteUserCompaniesCommandHandler : IRequestHandler<DeleteUserCompaniesCommand, Result>
        {
            private readonly IUserCompanyRepository _repository;

            public DeleteUserCompaniesCommandHandler(IUserCompanyRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(DeleteUserCompaniesCommand request, CancellationToken cancellationToken)
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