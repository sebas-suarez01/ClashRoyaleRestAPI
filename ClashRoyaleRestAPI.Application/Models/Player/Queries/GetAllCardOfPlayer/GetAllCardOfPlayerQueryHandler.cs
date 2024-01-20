using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllCardOfPlayer;

internal class GetAllCardOfPlayerQueryHandler : IQueryHandler<GetAllCardOfPlayerQuery, IEnumerable<CardModel>>
{
    private readonly IPlayerRepository _repository;

    public GetAllCardOfPlayerQueryHandler(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<CardModel>>> Handle(GetAllCardOfPlayerQuery request, CancellationToken cancellationToken)
    {
        var playerId = PlayerId.Create(request.Id);

        IEnumerable<CardModel> cards = await _repository.GetAllCardsOfPlayerAsync(playerId);

        return Result.Create(cards);
    }
}
