using ClashRoyaleRestAPI.Domain.Models.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories
{
    public interface ICardRepository : IBaseRepository<CardModel, int>
    {
        public Task<IEnumerable<CardModel>> GetCardsByNameAsync(string name);
    }
}
