using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdatePlayerRank;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers
{
    internal class UpdatePlayerRankExceptionHandler
        : RequestExceptionHandler<UpdatePlayerRankCommand, int>
    {
    }
}
