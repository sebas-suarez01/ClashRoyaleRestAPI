using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayer;

internal class GetAllPlayerQueryHandler : GetAllModelQueryHandler<PlayerModel, PlayerId>
{
    public GetAllPlayerQueryHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
