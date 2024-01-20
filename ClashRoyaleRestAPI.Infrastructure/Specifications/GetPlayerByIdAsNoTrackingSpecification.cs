using ClashRoyaleRestAPI.Application.Specifications;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications;

internal class GetPlayerByIdAsNoTrackingSpecification : Specification<PlayerModel>
{
    public GetPlayerByIdAsNoTrackingSpecification(PlayerId id) : base(c => c.Id == id)
    {
        AsNoTracking = true;
    }
}
