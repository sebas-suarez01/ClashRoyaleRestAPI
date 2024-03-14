using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerById;

internal class GetPlayerByIdQueryHandler : GetModelByIdQueryHandler<PlayerModel, PlayerId>
{
    public GetPlayerByIdQueryHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
