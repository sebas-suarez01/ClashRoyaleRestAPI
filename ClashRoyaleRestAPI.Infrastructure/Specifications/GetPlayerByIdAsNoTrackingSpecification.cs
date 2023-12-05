using ClashRoyaleRestAPI.Application.Specifications;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications;

internal class GetPlayerByIdAsNoTrackingSpecification : Specification<PlayerModel>
{
    public GetPlayerByIdAsNoTrackingSpecification() : base(null)
    {
        AsNoTracking = true;
    }
}
