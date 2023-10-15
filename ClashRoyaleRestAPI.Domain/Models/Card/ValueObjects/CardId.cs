using ClashRoyaleRestAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Models.Card.ValueObjects
{
    public sealed class CardId : ValueObject
    {
        public Guid Value { get; }

        private CardId(Guid value)
        {
            Value = value;
        }
        private CardId() { }

        public static CardId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static CardId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
