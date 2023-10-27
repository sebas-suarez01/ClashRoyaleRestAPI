using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories
{
    public interface IWarRepository : IBaseRepository<WarModel, int>
    {
        public Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date);
    }
}
