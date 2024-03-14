using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.User.ExceptionHandlers
{
    internal class GetUserByIdExceptionHandler
        : RequestExceptionHandler<GetModelByIdQuery<UserModel, string>, UserModel, string>
    {
    }
}
