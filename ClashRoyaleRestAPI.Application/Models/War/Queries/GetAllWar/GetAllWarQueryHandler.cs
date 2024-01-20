using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.War.Queries.GetAllWar;

internal class GetAllWarQueryHandler : GetAllModelQueryHandler<WarModel, WarId>
{
    public GetAllWarQueryHandler(IWarRepository repository) : base(repository)
    {
    }
}
