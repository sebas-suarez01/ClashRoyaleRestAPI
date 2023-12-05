using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Specifications.Models.Challenge
{
    public class GetAllChallengeOpenSpecification : Specification<ChallengeModel>
    {
        public GetAllChallengeOpenSpecification() : base(c => c.IsOpen)
        {
        }
    }
}
