using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;

namespace Scheduler.Api.CompaniesOpeningHours
{
    [ApiController]
    public class DeleteCompanyOpeningHours : Controller
    {
        private readonly IMediator _mediator;

        public DeleteCompanyOpeningHours(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("/api/DeleteCompanyOpeningHours/{id}")]
        public async Task<IActionResult> Delete(Guid id) => await _mediator.Send(new DeleteCompanyOpeningHoursCommand(id)).Process();

        public class DeleteCompanyOpeningHoursCommand : IRequest<Result>
        {
            public DeleteCompanyOpeningHoursCommand(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class DeleteCompanyOpeningHoursCommandHandler : IRequestHandler<DeleteCompanyOpeningHoursCommand, Result>
        {
            private readonly ICompanyOpeningHoursRepository _repository;

            public DeleteCompanyOpeningHoursCommandHandler(ICompanyOpeningHoursRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(DeleteCompanyOpeningHoursCommand request, CancellationToken cancellationToken)
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