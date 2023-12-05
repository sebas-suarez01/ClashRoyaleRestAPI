using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications.Models.Card;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models;

internal class CardRepository : BaseRepository<CardModel, int>, ICardRepository
{
    public CardRepository(ClashRoyaleDbContext context) : base(context)
    {
    }

    #region Interface Methods
    public async Task<IEnumerable<CardModel>> GetCardsByNameAsync(string name)
    {
        return await ApplySpecification(new GetCardsByNameSpecification(name)).ToListAsync();
    }

    #endregion
}
