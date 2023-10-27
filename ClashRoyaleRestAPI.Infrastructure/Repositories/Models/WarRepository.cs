using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models
{
    internal class WarRepository : BaseRepository<WarModel, int>, IWarRepository
    {
        public WarRepository(ClashRoyaleDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date)
        {
            return (await GetAllAsync()).Where(w => w.StartDate > date);
        }
    }
}
