using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Challenge
{
    internal class GetAllChallengeOpenSpecification : Specification<ChallengeModel>
    {
        public GetAllChallengeOpenSpecification() : base(c => c.IsOpen)
        {
        }
    }
}
