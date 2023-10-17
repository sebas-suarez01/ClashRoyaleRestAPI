using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Common.Commands.AddModel
{
    public class AddModelCommandHandler<TRequest, TModel, UId> : IRequestHandler<TRequest, UId>
        where TModel : IEntity<UId>
        where TRequest : AddModelCommand<TModel, UId>
    {
        private readonly IBaseRepository<TModel, UId> _repository;
        public AddModelCommandHandler(IBaseRepository<TModel, UId> repository)
        {
            _repository = repository;
        }

        public async Task<UId> Handle(TRequest request, CancellationToken cancellationToken)=>
            await _repository.Add(request.Model);
    }
}
