using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Interfaces.Auth
{
    public interface IJwtTokenProvider
    {
        LoginResponse CreateToken(UserModel user, IList<string> roles);
    }
}
