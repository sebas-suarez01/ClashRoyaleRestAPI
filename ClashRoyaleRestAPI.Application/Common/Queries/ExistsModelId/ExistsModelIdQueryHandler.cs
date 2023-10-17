using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Common.Queries.ExistsModelId
{
    public class ExistsModelIdQueryHandler<TRequest, TModel, UId> : IRequestHandler<TRequest, bool>
        where TModel : IEntity<UId>
        where TRequest : ExistsModelIdQuery<TModel, UId>
    {
        private readonly IBaseRepository<TModel, UId> _repository;
        public ExistsModelIdQueryHandler(IBaseRepository<TModel, UId> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(TRequest request, CancellationToken cancellationToken) =>
            await _repository.ExistsId(request.Id);
    }
}
