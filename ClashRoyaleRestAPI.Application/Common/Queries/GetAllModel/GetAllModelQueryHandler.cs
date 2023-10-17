using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Errors;
using ClashRoyaleRestAPI.Domain.Common.Exceptions;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
