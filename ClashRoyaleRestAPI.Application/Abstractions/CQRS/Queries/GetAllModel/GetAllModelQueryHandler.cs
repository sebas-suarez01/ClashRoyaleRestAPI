using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetAllModel;

public class GetAllModelQueryHandler<TModel, UId> : IQueryHandler<GetAllModelQuery<TModel, UId>, PageList<TModel>>
    where TModel : class, IEntity<UId>
{
    private readonly IBaseRepository<TModel, UId> _repository;
    public GetAllModelQueryHandler(IBaseRepository<TModel, UId> repository)
    {
        _repository = repository;
    }

    public async Task<Result<PageList<TModel>>> Handle(GetAllModelQuery<TModel, UId> request, CancellationToken cancellationToken)
    {
        PageList<TModel> models = await _repository.GetAllAsync(request.SortOrder, request.Page, request.PageSize);

        return Result.Create(models);
    }
}
