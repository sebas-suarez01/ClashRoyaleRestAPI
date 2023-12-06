using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdatePlayerRank;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers;

internal class UpdatePlayerRankExceptionHandler
    : RequestExceptionHandler<UpdatePlayerRankCommand, int>
{
}
