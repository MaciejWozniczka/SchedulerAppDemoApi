using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.Companies
{
    [ApiController]
    public class DeleteCompany : Controller
    {
        private readonly IMediator _mediator;

        public DeleteCompany(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("/api/DeleteCompany/{id}")]
        public async Task<IActionResult> Delete(Guid id) => await _mediator.Send(new DeleteCompanyCommand(id)).Process();

        public class DeleteCompanyCommand : IRequest<Result>
        {
            public DeleteCompanyCommand(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Result>
        {
            private readonly ICompanyRepository _repository;

            public DeleteCompanyCommandHandler(ICompanyRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
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