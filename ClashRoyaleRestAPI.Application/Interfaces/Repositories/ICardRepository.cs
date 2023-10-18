using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories
{
    public interface ICardRepository : IBaseRepository<CardModel, int>
    {
        public Task<IEnumerable<CardModel>> GetCardsByNameAsync(string name);
    }
}
