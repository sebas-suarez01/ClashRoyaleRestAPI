using ClashRoyaleRestAPI.Domain.Common.Base;
using ClashRoyaleRestAPI.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Player.ValueObjects
{
    public sealed class PlayerId : BaseIdValueObject
    {
        public PlayerId(Guid value) : base(value)
        {
        }
    }
}
}
