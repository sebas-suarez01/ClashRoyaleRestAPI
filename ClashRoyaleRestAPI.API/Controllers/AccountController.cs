using AutoMapper;
using ClashRoyaleRestAPI.API.Common.Mapping.Objects;
using ClashRoyaleRestAPI.Application.Auth;
using ClashRoyaleRestAPI.Application.Auth.Account.Commands.RegisterUser;
using ClashRoyaleRestAPI.Application.Auth.Account.Queries.LoginUser;
using ClashRoyaleRestAPI.Application.Auth.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers
{
    [Route("api/account")]
    public class AccountController : ApiController
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public AccountController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        // POST api/account/register/user
        [HttpPost("register/user")]
        public async Task<IActionResult> RegisterUser(RegisterRequest request)
        {
            var registerModel = _mapper.Map<RegisterModel>(request);

            var comamnd = new RegisterUserCommand(registerModel);

            var result = await _sender.Send(comamnd);

            return result.IsSuccess ? Created($"api/users/{result.Value}", result.Value) : Problem(result.Errors);
        }

        // POST api/account/login/user
        [HttpPost("login/user")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginModel = _mapper.Map<LoginModel>(request);

            var query = new LoginUserQuery(loginModel);

            var result = await _sender.Send(query);

            return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
        }

        [Authorize(Roles = UserRoles.SUPERADMIN)]
        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpPost("register/admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterRequest request)
        {
            var registerModel = _mapper.Map<RegisterModel>(request);

            var comamnd = new RegisterUserCommand(registerModel, RoleEnum.Admin);

            var result = await _sender.Send(comamnd);

            return result.IsSuccess ? NoContent() : Problem(result.Errors);
        }

    }
}
