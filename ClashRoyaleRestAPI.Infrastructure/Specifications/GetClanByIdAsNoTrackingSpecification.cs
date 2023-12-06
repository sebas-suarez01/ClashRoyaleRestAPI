using ClashRoyaleRestAPI.Application.Specifications;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications;

internal class GetClanByIdAsNoTrackingSpecification : Specification<ClanModel>
{
    public GetClanByIdAsNoTrackingSpecification() : base(null)
    {
    }
}
