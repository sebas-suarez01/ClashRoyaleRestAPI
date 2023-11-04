using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddClan;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers
{
    internal class AddClanExceptionHandler : RequestExceptionHandler<AddClanCommand, int, int>
    {
    }
}
