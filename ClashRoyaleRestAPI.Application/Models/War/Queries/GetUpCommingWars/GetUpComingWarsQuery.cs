using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.War.Queries.GetUpCommingWars;

public record GetUpComingWarsQuery(DateTime Date) : IQuery<IEnumerable<WarModel>>;
