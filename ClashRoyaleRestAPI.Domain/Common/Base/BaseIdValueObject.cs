using ClashRoyaleRestAPI.Domain.Card.ValueObjects;
using ClashRoyaleRestAPI.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Common.Base
{
    public class BaseIdValueObject : ValueObject
    {
        public Guid Value { get; private set; }

        public BaseIdValueObject(Guid value)
        {
            Value = value;
        }

        public static CardId CreateUnique()
        {
            return new CardId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
