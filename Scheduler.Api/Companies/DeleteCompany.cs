using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Data;
using Scheduler.Api.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler.Api.Companies
{
    [ApiController]
    public class DeleteInputData : Controller
    {
        private readonly IMediator _mediator;

        public DeleteInputData(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("/api/InputData/{id}")]
        public async Task<IActionResult> Delete(Guid id) => await _mediator.Send(new DeleteInputDataCommand(id)).Process();

        public class DeleteInputDataCommand : IRequest<Result>
        {
            public DeleteInputDataCommand(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class DeleteInputDataCommandHandler : IRequestHandler<DeleteInputDataCommand, Result>
        {
            private readonly ICompanyRepository _repository;

            public DeleteInputDataCommandHandler(ICompanyRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(DeleteInputDataCommand request, CancellationToken cancellationToken)
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