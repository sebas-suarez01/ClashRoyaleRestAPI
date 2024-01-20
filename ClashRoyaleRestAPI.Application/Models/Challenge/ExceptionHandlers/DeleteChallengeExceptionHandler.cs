using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.ExceptionHandlers;

internal class DeleteChallengeExceptionHandler
    : RequestExceptionHandler<DeleteModelCommand<ChallengeModel, ChallengeId>, string>
{
}
