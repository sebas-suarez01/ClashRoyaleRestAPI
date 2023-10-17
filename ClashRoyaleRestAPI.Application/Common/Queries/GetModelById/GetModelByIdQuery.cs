using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Common.Queries.GetModelById
{
    public record GetModelByIdQuery<TModel, UId>(UId Id) : IRequest<ErrorOr<TModel>>
        where TModel : IEntity<UId>;
}
