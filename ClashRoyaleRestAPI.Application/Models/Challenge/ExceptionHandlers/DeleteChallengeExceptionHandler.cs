using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.ExceptionHandlers;

internal class DeleteChallengeExceptionHandler
    : RequestExceptionHandler<DeleteModelCommand<ChallengeModel, ChallengeId>, string>
{
}
