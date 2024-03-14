using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.AddModel;

public class AddModelCommandHandler<TModel, UId> : ICommandHandler<AddModelCommand<TModel, UId>, UId>
    where TModel : class, IEntity<UId>
{
    private readonly IBaseRepository<TModel, UId> _repository;
    public AddModelCommandHandler(IBaseRepository<TModel, UId> repository)
    {
        _repository = repository;
    }

    public async Task<Result<UId>> Handle(AddModelCommand<TModel, UId> request, CancellationToken cancellationToken = default)
    {
        await _repository.Add(request.Model);

        return request.Model.Id;
    }
}
