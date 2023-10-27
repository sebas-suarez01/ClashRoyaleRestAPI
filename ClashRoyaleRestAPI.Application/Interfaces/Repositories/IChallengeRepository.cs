using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories
{
    public interface IChallengeRepository : IBaseRepository<ChallengeModel, int>
    {
        Task<IEnumerable<ChallengeModel>> GetAllOpenChallenges();
    }
}
