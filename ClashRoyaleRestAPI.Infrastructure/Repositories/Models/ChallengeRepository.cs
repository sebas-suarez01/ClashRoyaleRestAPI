using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Challenge;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models
{
    internal class ChallengeRepository : BaseRepository<ChallengeModel, int>, IChallengeRepository
    {
        public ChallengeRepository(ClashRoyaleDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ChallengeModel>> GetAllOpenChallenges() => (await GetAllAsync()).Where(x => x.IsOpen).ToList();
    }
}
