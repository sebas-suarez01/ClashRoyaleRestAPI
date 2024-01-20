using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;

namespace ClashRoyaleRestAPI.Domain.Models;

public class PlayerModel : BaseEntity<PlayerId>
{
    private PlayerModel() 
    {
        Id = PlayerId.CreateUnique();
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
        return new PlayerModel
        {
            Alias = alias,
            Elo = elo,
            Level = level,
        };
    }
    public static PlayerModel Create(Guid id, string alias, int elo, int level)
    {
        return new PlayerModel
        {
            Id = PlayerId.Create(id),
            Alias = alias,
            Elo = elo,
            Level = level,
        };
    }
    public void AddCard(CollectionModel collection) => _cards.Add(collection);
    public void AddFavoriteCard(CardModel card) => FavoriteCard ??= card; 
    public bool HaveCard(int cardId) => Cards.Any(c => c.Card is not null && c.Card.Id == cardId);
    public void ChangeAlias(string alias) => Alias = alias;
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
    }

}
