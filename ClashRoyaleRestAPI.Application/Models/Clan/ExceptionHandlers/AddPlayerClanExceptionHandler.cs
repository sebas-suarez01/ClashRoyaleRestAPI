using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddPlayerClan;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers
{
    internal class AddPlayerClanExceptionHandler : RequestExceptionHandler<AddPlayerClanCommand, int>
    {
    }
}
