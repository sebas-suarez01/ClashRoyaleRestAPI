using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected readonly IMediator _sender;

    protected ApiController(IMediator sender)
    {
        _sender = sender;
    }

    protected IActionResult Problem(Error[] errors)
    {
        if(errors.Length > 1)
            return BadRequest(string.Join("\n", errors.AsEnumerable()));

        return Problem(errors[0]);
    }

    protected IActionResult Problem(Error error)
    {

        if (error == ErrorCode.IdNotFound ||
            error == ErrorCode.ModelNotFound ||
            error == ErrorCode.UsernameNotFound)
            return NotFound(error.Description);

        if (error == ErrorCode.IdsNotMatch ||
            error == ErrorCode.InvalidCredentials ||
            error == ErrorCode.InvalidPassword ||
            error == ErrorCode.ChallengeClosed ||
            error == ErrorCode.PlayerNotHaveCard)
            return BadRequest(error.Description);

        if (error == ErrorCode.DuplicateId ||
            error == ErrorCode.DuplicateUsername ||
            error == ErrorCode.DuplicateIndex)
            return Conflict(error.Description);


        return Problem();
    }
}
