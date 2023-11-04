using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.ExceptionHandlers
{
    internal class DeleteChallengeExceptionHandler
        : RequestExceptionHandler<DeleteModelCommand<ChallengeModel, int>, int>
    {
    }
}
