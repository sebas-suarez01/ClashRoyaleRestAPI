using ClashRoyaleRestAPI.Application.Auth;
using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Application.Auth.Utils;

namespace ClashRoyaleRestAPI.Application.Interfaces.Auth
{
    public interface IAccountRepository
    {
        Task<UserResponse> RegisterUserAsync(RegisterModel registerModel, RoleEnum role);
        Task<LoginResponse> LoginUserAsync(LoginModel loginModel);
    }
}
