using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel
{
    public class AddModelCommandHandler<TModel, UId> : ICommandHandler<AddModelCommand<TModel, UId>, UId>
        where TModel : IEntity<UId>
    {
        private readonly IBaseRepository<TModel, UId> _repository;
        public AddModelCommandHandler(IBaseRepository<TModel, UId> repository)
        {
            _repository = repository;
        }

        public async Task<Result<UId>> Handle(AddModelCommand<TModel, UId> request, CancellationToken cancellationToken)
        {
            await _repository.Add(request.Model);

            return request.Model.Id;
        }
    }
}
