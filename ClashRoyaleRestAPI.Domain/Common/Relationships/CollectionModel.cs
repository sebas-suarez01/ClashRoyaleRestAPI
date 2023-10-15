using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Common.Relationships
{
    public class CollectionModel
    {
        public PlayerModel? Player { get; set; }
        public CardModel? Card { get; set; }
        public int Level { get; set; }
        public DateTime Date { get; set; }
    }
}
