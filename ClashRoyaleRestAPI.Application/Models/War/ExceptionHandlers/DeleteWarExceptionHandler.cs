using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.War.ExceptionHandlers
{
    internal class DeleteWarExceptionHandler :
        RequestExceptionHandler<DeleteModelCommand<WarModel, int>, int>
    {
    }
}
