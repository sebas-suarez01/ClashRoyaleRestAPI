using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerWithRequirements;

public record GetAllPlayerWithRequirementsQuery(string? Name,
                                                int? Elo,
                                                string? SortColumn,
                                                string? SortOrder,
                                                int Page,
                                                int PageSize) : IQuery<PageList<PlayerModel>>;
