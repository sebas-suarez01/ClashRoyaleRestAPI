using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Models.Battle.ValueObjects;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Domain.Models.Battle
{
    public class BattleModel : IEntity<BattleId>
    {
        public BattleId Id { get; set; }
        public int AmountTrophies { get; set; }
        public PlayerModel? Winner { get; set; }
        public PlayerModel? Loser { get; set; }
        public int DurationInSeconds { get; set; }
        public DateTime Date { get; set; }
    }
}
