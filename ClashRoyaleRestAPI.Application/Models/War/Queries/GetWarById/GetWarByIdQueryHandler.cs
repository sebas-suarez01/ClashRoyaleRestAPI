using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.War.Queries.GetWarById;

internal class GetWarByIdQueryHandler : GetModelByIdQueryHandler<WarModel, WarId>
{
    public GetWarByIdQueryHandler(IWarRepository repository) : base(repository)
    {
    }
}
