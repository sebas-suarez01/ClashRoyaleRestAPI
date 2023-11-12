using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.User.ExceptionHandlers
{
    internal class GetUserByIdExceptionHandler
        : RequestExceptionHandler<GetModelByIdQuery<UserModel, string>, UserModel, string>
    {
    }
}
