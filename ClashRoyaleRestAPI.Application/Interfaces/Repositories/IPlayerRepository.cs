using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories
{
    public interface IPlayerRepository : IBaseRepository<PlayerModel, int>
    {
        public Task<PlayerModel?> GetSingleByIdAsync(int id, bool fullLoad = false);
        public Task<IEnumerable<PlayerModel>> GetPlayersByAliasAsync(string alias);
        public Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(int playerId);
        public Task AddCard(int playerId, int cardId);
        public Task UpdateAlias(int playerId, string alias);
    }
}
