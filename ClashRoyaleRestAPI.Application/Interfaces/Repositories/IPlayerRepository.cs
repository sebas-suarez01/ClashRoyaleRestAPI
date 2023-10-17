using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories
{
    public interface IPlayerRepository : IBaseRepository<PlayerModel, int>
    {
        //public Task<PlayerModel> GetSingleByIdAsync(int id, bool fullLoad = false);
        public Task<IEnumerable<PlayerModel>> GetPlayersByAliasAsync(string alias);
        //public Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(int id);
        public Task AddCard(int playerId, int cardId);
        public Task<PlayerModel> UpdateAlias(int playerId, string alias);
    }
}
