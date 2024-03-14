using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdatePlayerRank;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers;

internal class UpdatePlayerRankExceptionHandler
    : RequestExceptionHandler<UpdatePlayerRankCommand, string>
{
}
