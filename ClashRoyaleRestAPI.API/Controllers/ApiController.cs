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

            if (error == ErrorTypes.Models.IdNotFound)
                return NotFound(error.Description);
            if (error == ErrorTypes.Models.ModelNotFound)
                return NotFound(error.Description);
            if (error == ErrorTypes.Models.IdsNotMatch)
                return BadRequest(error.Description);
            if (error == ErrorTypes.Models.DuplicateId)
                return Conflict(error.Description);

            return Problem();
        }
    }
}
