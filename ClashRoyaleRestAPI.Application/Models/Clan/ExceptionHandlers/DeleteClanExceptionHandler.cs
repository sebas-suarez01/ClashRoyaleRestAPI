using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers
{
    internal class DeleteClanExceptionHandler 
        : RequestExceptionHandler<DeleteModelCommand<ClanModel, int>, int>
    {
    }
}
