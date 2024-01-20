using ClashRoyaleRestAPI.Application.Specifications;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications;

internal class GetClanByIdAsNoTrackingSpecification : Specification<ClanModel>
{
    public GetClanByIdAsNoTrackingSpecification(ClanId id) : base(c => c.Id == id)
    {
        AsNoTracking = true;
    }
}
