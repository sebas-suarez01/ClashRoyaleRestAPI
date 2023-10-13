using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Card.Implementation
{
    public sealed class Structure : Card
    {
        public float Radius { get; set; }
        public int HitPoints { get; set; }
        public float HitSpeed { get; set; }
        public int LifeTime { get; set; }
        public float Range { get; set; }
    }
}
