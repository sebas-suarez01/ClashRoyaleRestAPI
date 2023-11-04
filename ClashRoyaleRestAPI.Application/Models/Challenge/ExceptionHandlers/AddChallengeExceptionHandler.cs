using ClashRoyaleRestAPI.Application.Common.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.ExceptionHandlers
{
    internal class AddChallengeExceptionHandler
        : RequestExceptionHandler<AddModelCommand<ChallengeModel, int>, int, int>
    {
    }
}
