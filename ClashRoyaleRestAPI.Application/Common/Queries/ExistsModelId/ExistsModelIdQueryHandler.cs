using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Common.Queries.ExistsModelId
{
    public class ExistsModelIdQueryHandler<UId> : IQueryHandler<ExistsModelIdQuery<UId>, bool>
    {
        private readonly IBaseRepository<IEntity<UId>, UId> _repository;
        public ExistsModelIdQueryHandler(IBaseRepository<IEntity<UId>, UId> repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> Handle(ExistsModelIdQuery<UId> request, CancellationToken cancellationToken)
        {
            return await _repository.ExistsId(request.Id);
        }
    }
}
