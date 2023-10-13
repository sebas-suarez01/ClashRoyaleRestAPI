using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Card.Implementation
{
    public sealed class Spell : Card
    {
        public float Radius { get; set; }
        public int TowerDamage { get; set; }
        public int LifeTime { get; set; }
    }
}
