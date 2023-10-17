using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel
{
    public record UpdateModelCommand<TModel, UId>(TModel Model): IRequest
        where TModel : IEntity<UId>;
}
