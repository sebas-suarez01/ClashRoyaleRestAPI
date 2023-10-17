using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Common.Commands.AddModel
{
    public record AddModelCommand<TModel, UId>(TModel Model) : IRequest<UId>
        where TModel: IEntity<UId>;
}
