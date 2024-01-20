using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.ExceptionHandlers;

internal class GetChallengeByIdExceptionHandler
    : RequestExceptionHandler<GetModelByIdQuery<ChallengeModel, ChallengeId>, ChallengeModel, string>
{
}
