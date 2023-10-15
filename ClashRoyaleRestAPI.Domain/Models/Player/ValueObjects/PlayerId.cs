using ClashRoyaleRestAPI.Domain.Common;

namespace ClashRoyaleRestAPI.Domain.Models.Player.ValueObjects
{
    public sealed class PlayerId : ValueObject
    {
        public Guid Value { get; }

        private PlayerId(Guid value)
        {
            Value = value;
        }
        private PlayerId() { }

        public static PlayerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public static PlayerId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
