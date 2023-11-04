using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.ExceptionHandlers
{
    internal class GetChallengeByIdExceptionHandler
        : RequestExceptionHandler<GetModelByIdQuery<ChallengeModel, int>, ChallengeModel, int>
    {
    }
}
