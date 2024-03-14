using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllClanWithRequirements;

public record GetAllClanWithRequirementsQuery(string? Name,
                                              string? Region,
                                              int? MinTrophies,
                                              int? TrophiesInWar,
                                              bool? Availables,
                                              string? SortColumn,
                                              string? SortOrder,
                                              int Page = 1,
                                              int PageSize=10) : IQuery<PageList<ClanModel>>;
