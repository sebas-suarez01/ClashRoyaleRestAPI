using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using MediatR;

namespace ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel
{
    public class GetAllModelQueryHandler<TRequest, TModel, UId> : IRequestHandler<TRequest, IEnumerable<TModel>>
        where TModel : IEntity<UId>
        where TRequest : GetAllModelQuery<TModel, UId>
    {
        private readonly IBaseRepository<TModel, UId> _repository;
        public GetAllModelQueryHandler(IBaseRepository<TModel, UId> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TModel>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<TModel?> models = await _repository.GetAllAsync();

            return models!;
        }
    }
}
