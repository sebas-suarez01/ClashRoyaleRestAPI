using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.War;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models
{
    public class WarRepository : BaseRepository<WarModel, int>, IWarRepository
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
