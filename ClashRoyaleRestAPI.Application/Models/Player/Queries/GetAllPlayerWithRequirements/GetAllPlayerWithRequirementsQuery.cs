using ClashRoyaleRestAPI.Application.Abstractions.PageQuery;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerWithRequirements;

public record GetAllPlayerWithRequirementsQuery(PlayerPageQuery PageQuery) : IQuery<PageList<PlayerModel>>;
