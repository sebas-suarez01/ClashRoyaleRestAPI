using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Application.Auth.User;

namespace ClashRoyaleRestAPI.Application.Interfaces.Auth
{
    public interface IJwtTokenProvider
    {
        LoginResponse CreateToken(UserModel user, IList<string> roles);
    }
}
