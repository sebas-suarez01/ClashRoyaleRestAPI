using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.ExceptionHandlers
{
    internal class DeleteChallengeExceptionHandler
        : RequestExceptionHandler<DeleteModelCommand<ChallengeModel, int>, int>
    {
    }
}
