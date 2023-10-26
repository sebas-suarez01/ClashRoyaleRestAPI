using ClashRoyaleRestAPI.Domain.Models.Challenge;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories
{
    public interface IChallengeRepository : IBaseRepository<ChallengeModel, int>
    {
        Task<IEnumerable<ChallengeModel>> GetAllOpenChallenges();
    }
}
