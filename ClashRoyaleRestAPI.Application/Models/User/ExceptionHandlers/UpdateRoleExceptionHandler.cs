using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.User.Commands.UpdateRole;

namespace ClashRoyaleRestAPI.Application.Models.User.ExceptionHandlers;

internal class UpdateRoleExceptionHandler
    : RequestExceptionHandler<UpdateRoleCommand, string>
{
}
