using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel
{
    public class UpdateModelCommandHandler<TRequest, TModel, UId> : IRequestHandler<TRequest>
        where TModel : IEntity<UId>
        where TRequest : DeleteModelCommand<TModel, UId>
    {
        private readonly IBaseRepository<TModel, UId> _repository;
        public UpdateModelCommandHandler(IBaseRepository<TModel, UId> repository)
        {
            _repository = repository;
        }
        public async Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            await _repository.Update(request.Model);
        }
    }
}
