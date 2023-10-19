using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Common.Queries.GetModelById
{
    public class GetModelByIdHandler<TModel, UId> : IQueryHandler<GetModelByIdQuery<TModel, UId>, TModel>
        where TModel : IEntity<UId>
    {
        private readonly IBaseRepository<TModel, UId> _repository;
        public GetModelByIdHandler(IBaseRepository<TModel, UId> repository)
        {
            _repository = repository;
        }

        public async Task<Result<TModel>> Handle(GetModelByIdQuery<TModel, UId> request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetSingleByIdAsync(request.Id);

            if (model is null)
                return Result.Failure<TModel>(ErrorTypes.Models.IdNotFound);

            return model;
        }
    }
}
