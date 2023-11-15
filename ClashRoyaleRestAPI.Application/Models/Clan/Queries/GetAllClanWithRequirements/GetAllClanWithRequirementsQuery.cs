using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllClanWithRequirements
{
    public record GetAllClanWithRequirementsQuery(string? Name,
                                                  string? Region,
                                                  int? MinTrophies,
                                                  int? TrophiesInWar,
                                                  bool? Availables,
                                                  string? SortColumn,
                                                  string? SortOrder) : IQuery<IEnumerable<ClanModel>>;
}
