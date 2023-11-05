using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.ExceptionHandlers
{
    internal class GetChallengeByIdExceptionHandler
        : RequestExceptionHandler<GetModelByIdQuery<ChallengeModel, int>, ChallengeModel, int>
    {
    }
}
