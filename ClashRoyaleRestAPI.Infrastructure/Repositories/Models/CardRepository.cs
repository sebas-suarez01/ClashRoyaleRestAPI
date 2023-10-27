using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models
{
    internal class CardRepository : BaseRepository<CardModel, int>, ICardRepository
    {
        public CardRepository(ClashRoyaleDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CardModel>> GetCardsByNameAsync(string name)
        {
            return await _context.Cards.Where(c => c.Name!.Contains(name)).ToListAsync();
        }
    }
}
