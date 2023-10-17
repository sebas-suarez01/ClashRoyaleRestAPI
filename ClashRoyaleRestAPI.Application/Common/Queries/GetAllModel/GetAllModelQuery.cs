using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel
{
    public record GetAllModelQuery<TModel, UId>() : IRequest<IEnumerable<TModel>>
        where TModel : IEntity<UId>;
}
