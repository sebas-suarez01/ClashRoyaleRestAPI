using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel
{
    public record DeleteModelCommand<TModel, UId>(TModel Model) : IRequest
        where TModel : IEntity<UId>;
}
