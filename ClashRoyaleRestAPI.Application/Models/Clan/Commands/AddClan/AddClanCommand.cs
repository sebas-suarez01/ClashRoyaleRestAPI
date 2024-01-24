using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddClan;

public record AddClanCommand(PlayerId PlayerId, ClanModel Clan) : ICommand<Guid>;
