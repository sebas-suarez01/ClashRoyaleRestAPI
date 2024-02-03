using ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;

namespace ClashRoyaleRestAPI.Domain.Models;

public class PlayerModel : Entity<PlayerId>
{
    private PlayerModel(Guid id)
    {
        Id = ValueObjectId.Create<PlayerId>(id);
    }
    private PlayerModel()
    {
    }
    public string? Alias { get; private set; }
    public int Elo { get; private set; }
    public int Level { get; private set; }
    public int Victories { get; private set; }
    public int CardAmount { get; private set; }
    public int MaxElo { get; private set; }
    public CardModel? FavoriteCard { get; private set; }

    private readonly List<CollectionModel> _cards = new();
    public IReadOnlyCollection<CollectionModel> Cards => _cards;

    public static PlayerModel Create(string alias, int elo, int level)
    {
        var player = new PlayerModel(Guid.NewGuid())
        {
            Alias = alias,
            Elo = elo,
            Level = level,
        };

        player.RaiseDomainEvent(new PlayerCreatedDomainEvent(Guid.NewGuid(), player.Id.Value));

        return player;
    }
    public static PlayerModel Create(Guid id, string alias, int elo, int level)
    {
        return new PlayerModel
        {
            Id = ValueObjectId.Create<PlayerId>(id),
            Alias = alias,
            Elo = elo,
            Level = level,
        };
    }
    public void AddCard(CollectionModel collection)
    {
        _cards.Add(collection);

        RaiseDomainEvent(new CardAddedDomainEvent(Guid.NewGuid(), Id.Value, collection.Card!.Id));
    }
    public void AddFavoriteCard(CardModel card)
    {
        FavoriteCard ??= card;

        RaiseDomainEvent(new FavoriteCardChangedDomainEvent(Guid.NewGuid(), Id.Value, card.Id));
    }
    public bool HaveCard(int cardId) => Cards.Any(c => c.Card is not null && c.Card.Id == cardId);
    public void ChangeAlias(string alias)
    {
        Alias = alias;

        RaiseDomainEvent(new PlayerNameChangedDomainEvent(Guid.NewGuid(), Id.Value, Alias));
    }
    public void AddCardAmount() => CardAmount += 1;
    private void UpdateMaxElo(int maxElo) => MaxElo = maxElo;
    public void AddVictory() => Victories += 1;
    public void UpdateElo(int elo)
    {
        if (MaxElo < Elo)
        {
            MaxElo = Elo;
            return;
        }

        Elo += elo;

        if (Elo > MaxElo)
            UpdateMaxElo(Elo);

        RaiseDomainEvent(new PlayerEloChangedDomainEvent(Guid.NewGuid(), Id.Value, elo));

    }

}
