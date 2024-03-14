using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.ExceptionHandlers;

internal class GetChallengeByIdExceptionHandler
    : RequestExceptionHandler<GetModelByIdQuery<ChallengeModel, ChallengeId>, ChallengeModel, string>
{
}
