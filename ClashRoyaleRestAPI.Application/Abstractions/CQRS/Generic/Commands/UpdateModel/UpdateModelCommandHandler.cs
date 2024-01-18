using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;

public class UpdateModelCommandHandler<TModel, UId> : ICommandHandler<UpdateModelCommand<TModel, UId>>
    where TModel : class, IEntity<UId>
{
    private readonly IBaseRepository<TModel, UId> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateModelCommandHandler(IBaseRepository<TModel, UId> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateModelCommand<TModel, UId> request, CancellationToken cancellationToken = default)
    {
        await _repository.Update(request.Model);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
