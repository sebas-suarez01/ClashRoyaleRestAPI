using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.ExceptionHandlers;

internal class AddChallengeExceptionHandler
    : RequestExceptionHandler<AddModelCommand<ChallengeModel, ChallengeId>, ChallengeId, string>
{
}
