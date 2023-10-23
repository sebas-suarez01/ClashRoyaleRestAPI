using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(Error[] errors)
        {
            var firstError = errors[0];

            return Problem(firstError);
        }

        protected IActionResult Problem(Error error)
        {

            if (error == ErrorTypes.Models.IdNotFound ||
                error == ErrorTypes.Models.ModelNotFound ||
                error == ErrorTypes.Auth.UsernameNotFound)
                return NotFound(error.Description);

            if (error == ErrorTypes.Models.IdsNotMatch ||
                error == ErrorTypes.Auth.InvalidCredentials ||
                error == ErrorTypes.Auth.InvalidPassword)
                return BadRequest(error.Description);

            if (error == ErrorTypes.Models.DuplicateId ||
                error == ErrorTypes.Auth.DuplicateUsername)
                return Conflict(error.Description);


            return Problem();
        }
    }
}
