using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers
{
    internal class DeletePlayerExceptionHandler : RequestExceptionHandler<DeleteModelCommand<PlayerModel, int>, int>
    {
    }
}
