using ClashRoyaleRestAPI.Domain.Common.Models;
using ClashRoyaleRestAPI.Domain.Player.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Player
{
    public sealed class Player : AggregateRoot<PlayerId>
    {
        public string? Alias { get; private set; }
        public int Elo { get; private set; }
        public int Level { get; private set; }
        public int Victories { get; private set; }
        public int CardAmount { get; private set; }
        public int MaxElo { get; private set; }
    }
}
