using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Common.Queries.ExistsModelId
{
    public record ExistsModelIdQuery<TModel, UId>(UId Id) : IRequest<bool>
        where TModel : IEntity<UId>;
}
