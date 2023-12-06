using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.ExceptionHandlers;

internal class AddChallengeExceptionHandler
    : RequestExceptionHandler<AddModelCommand<ChallengeModel, int>, int, int>
{
}
