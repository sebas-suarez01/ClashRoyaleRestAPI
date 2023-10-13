using ClashRoyaleRestAPI.Domain.Card.Enum;
using ClashRoyaleRestAPI.Domain.Card.ValueObjects;
using ClashRoyaleRestAPI.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Card
{
    public abstract class Card : AggregateRoot<CardId>
    {
        public string? Name { get; set; }
        public TypeCardEnum Type { get; set; }
        public string? Description { get; set; }
        public int Elixir { get; set; }
        public QualityCardEnum Quality { get; set; }
        public int Damage { get; set; }
        public bool AreaDamage { get; set; }
        public TargetCardEnum Target { get; set; }
        public int InitialLevel { get; set; }
        public string? ImageUrl { get; set; }
    }
}
