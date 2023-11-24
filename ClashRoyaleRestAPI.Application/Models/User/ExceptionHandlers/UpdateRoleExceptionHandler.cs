using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.User.Commands.UpdateRole;

namespace ClashRoyaleRestAPI.Application.Models.User.ExceptionHandlers;

internal class UpdateRoleExceptionHandler
    : RequestExceptionHandler<UpdateRoleCommand, string>
{
}
