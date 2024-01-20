using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerById;

internal class GetPlayerByIdHandler : GetModelByIdQueryHandler<PlayerModel, PlayerId>
{
    public GetPlayerByIdHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
