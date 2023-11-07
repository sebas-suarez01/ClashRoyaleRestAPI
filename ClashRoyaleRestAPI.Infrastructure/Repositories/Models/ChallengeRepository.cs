using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Challenge;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models
{
    internal class ChallengeRepository : BaseRepository<ChallengeModel, int>, IChallengeRepository
    {
        public ChallengeRepository(ClashRoyaleDbContext context) : base(context)
        {
        }


        #region Interface Methods

        public async Task<IEnumerable<ChallengeModel>> GetAllOpenChallenges()
        {
            return await ApplySpecification(new GetAllChallengeOpenSpecification()).ToListAsync();
        }

        #endregion

    }
}
