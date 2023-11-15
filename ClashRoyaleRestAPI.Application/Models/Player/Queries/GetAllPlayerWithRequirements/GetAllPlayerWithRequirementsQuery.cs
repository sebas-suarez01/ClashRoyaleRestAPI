using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerWithRequirements
{
    public record GetAllPlayerWithRequirementsQuery(string? Name,
                                                    int? Elo,
                                                    string? SortColumn,
                                                    string? SortOrder) : IQuery<IEnumerable<PlayerModel>>;
}
