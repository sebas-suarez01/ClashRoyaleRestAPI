using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.War;

namespace ClashRoyaleRestAPI.Application.War.Queries.GetUpCommingWars
{
    public record GetUpComingWarsQuery(DateTime Date) : IQuery<IEnumerable<WarModel>>;
}
