using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using ClashRoyaleRestAPI.Infrastructure.Specifications.Models.War;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models
{
    internal class WarRepository : BaseRepository<WarModel, int>, IWarRepository
    {
        public WarRepository(ClashRoyaleDbContext context) : base(context)
        {
        }

        #region Interface Methods

        public async Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date)
        {
            return await ApplySpecification(new GetWarByDateSpecification(date)).ToListAsync();
        }

        #endregion

    }
}
