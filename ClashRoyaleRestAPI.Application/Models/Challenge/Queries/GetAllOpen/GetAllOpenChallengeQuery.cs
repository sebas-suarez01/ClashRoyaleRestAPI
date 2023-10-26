using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Challenge;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Queries.GetAllOpen
{
    public record GetAllOpenChallengeQuery() : IQuery<IEnumerable<ChallengeModel>>;
}
