using ClashRoyaleRestAPI.Domain.Common.Interfaces;

namespace ClashRoyaleRestAPI.Domain.Models.Challenge
{
    public class ChallengeModel : IEntity<int>
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public int Cost { get; private set; }
        public int AmountReward { get; private set; }
        public DateTime StartDate { get; private set; }
        public int DurationInHours { get; private set; }
        public bool IsOpen { get; private set; }
        public int MinLevel { get; private set; }
        public int LossLimit { get; private set; }
    }
}
