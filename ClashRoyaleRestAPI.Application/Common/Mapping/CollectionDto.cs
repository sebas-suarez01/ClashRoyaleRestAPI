using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Common.Mapping
{
    public class CollectionDto
    {
        public CardModel? Card { get; set; }
        public int Level { get; set; }
        public DateTime Date { get; set; }
    }
}
