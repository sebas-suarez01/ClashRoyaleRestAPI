using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerById;

internal class GetPlayerByIdHandler : GetModelByIdQueryHandler<PlayerModel, int>
{
    public GetPlayerByIdHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
