using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Errors;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace ClashRoyaleRestAPI.Application.Common.Queries.GetModelById
{
    public class GetModelByIdHandler<TRequest, TModel, UId> : IRequestHandler<TRequest, ErrorOr<TModel>>
        where TModel : IEntity<UId>
        where TRequest : GetModelByIdQuery<TModel, UId>
    {
        private readonly IBaseRepository<TModel, UId> _repository;
        public GetModelByIdHandler(IBaseRepository<TModel, UId> repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<TModel>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetSingleByIdAsync(request.Id);

            return model ?? (ErrorOr<TModel>)Errors.Models.IdNotFound;
        }
    }
}
