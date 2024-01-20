using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories;

public interface IChallengeRepository : IBaseRepository<ChallengeModel, ChallengeId>
{
    Task<IEnumerable<ChallengeModel>> GetAllOpenChallenges();
}
