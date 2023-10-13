using ClashRoyaleRestAPI.Domain.Card.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Card.Implementation
{
    public sealed class Troop : Card
    {
        public int HitPoints { get; set; }
        public int Amount { get; set; }
        public float Range { get; set; }
        public SpeedCardEnum Speed { get; set; }
        public float HitSpeed { get; set; }
        public TransportCardEnum Transport { get; set; }
    }
}
