using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Relationships;

namespace ClashRoyaleRestAPI.Domain.Models
{
    public class ClanModel : IEntity<int>
    {
        private readonly List<ClanPlayersModel> _players = new();
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? Region { get; private set; }
        public bool TypeOpen { get; private set; }
        public int AmountMembers { get; private set; }
        public int TrophiesInWar { get; private set; }
        public int MinTrophies { get; private set; }
        public IReadOnlyCollection<ClanPlayersModel> Players => _players;

        public void AddPlayer(PlayerModel player, RankClan rank = RankClan.Member)
        {
            var playerClan = ClanPlayersModel.Create(player, this, rank);

            _players.Add(playerClan);
        }

        public void AddAmountMember()
        {
            AmountMembers += 1;
        }
        public void RemoveAmountMember()
        {
            AmountMembers += 1;
        }
    }
}
