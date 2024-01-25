using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;

public class DeleteModelCommandHandler<TModel, UId> : ICommandHandler<DeleteModelCommand<TModel, UId>>
    where TModel : class, IEntity<UId>
{
    private readonly IBaseRepository<TModel, UId> _repository;
    public DeleteModelCommandHandler(IBaseRepository<TModel, UId> repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteModelCommand<TModel, UId> request, CancellationToken cancellationToken = default)
    {
        TModel model = await _repository.GetSingleByIdAsync(request.Id);

        await _repository.Delete(model);

        return Result.Success();
    }
}
