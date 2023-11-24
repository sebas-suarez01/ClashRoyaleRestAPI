using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Auth.Utils;
using ClashRoyaleRestAPI.Application.Models.User.Commands.UpdateRole;
using ClashRoyaleRestAPI.Application.Models.User.Queries.GetUserByName;
using ClashRoyaleRestAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/users")]
public class UserController : ApiController
{
    public UserController(IMediator sender) : base(sender) { }

    // GET: api/users
    [HttpGet]
    public async Task<IActionResult> GetAll(string? sortOrder, int? page, int? pageSize)
    {
        var query = new GetAllModelQuery<UserModel, string>(sortOrder,
                                                            page.GetValueOrDefault(1),
                                                            pageSize.GetValueOrDefault(10));

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/users/username/{username}
    [HttpGet("username/{username}")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        var query = new GetUserByNameQuery(username);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/users/{id:string}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var query = new GetModelByIdQuery<UserModel, string>(id);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // DELETE api/users/{id:string}
    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.SUPERADMIN)]
    public async Task<IActionResult> Delete(string id)
    {
        var command = new DeleteModelCommand<UserModel, string>(id);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // PUT api/users/{id:string}
    [HttpPut("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.SUPERADMIN)]
    public async Task<IActionResult> UpdateRole(string id, RoleEnum role)
    {
        var command = new UpdateRoleCommand(id, UserRoles.MapRole(role));

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
