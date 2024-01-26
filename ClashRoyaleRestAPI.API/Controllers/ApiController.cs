using ClashRoyaleRestAPI.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected readonly ISender _sender;

    protected ApiController(ISender sender)
    {
        _sender = sender;
    }

    protected IActionResult Problem(Error[] errors)
    {
        return errors.Length > 1 
            ? BadRequest(string.Join("\n", errors.AsEnumerable())) 
            : Problem(errors[0]);
    }

    protected IActionResult Problem(Error error)
    {
        return Problem(statusCode: (int)error.HttpStatusCode, title: error.Code, detail: error.Description);
    }
}
