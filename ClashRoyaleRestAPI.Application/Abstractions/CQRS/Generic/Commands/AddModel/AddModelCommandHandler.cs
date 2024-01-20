using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;

public class AddModelCommandHandler<TModel, UId> : ICommandHandler<AddModelCommand<TModel, UId>, UId>
    where TModel : class, IEntity<UId>
{
    private readonly IBaseRepository<TModel, UId> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public AddModelCommandHandler(IBaseRepository<TModel, UId> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UId>> Handle(AddModelCommand<TModel, UId> request, CancellationToken cancellationToken = default)
    {
        await _repository.Add(request.Model);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return request.Model.Id;
    }
}
