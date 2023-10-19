using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel
{
    public class DeleteModelCommandHandler<TModel, UId> : ICommandHandler<DeleteModelCommand<TModel, UId>>
        where TModel : IEntity<UId>
    {
        private readonly IBaseRepository<TModel, UId> _repository;
        public DeleteModelCommandHandler(IBaseRepository<TModel, UId> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteModelCommand<TModel, UId> request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Model);

            return Result.Success();
        }
    }
}
