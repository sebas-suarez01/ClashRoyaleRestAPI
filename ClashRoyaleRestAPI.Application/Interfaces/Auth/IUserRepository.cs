using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Application.Auth.User;

namespace ClashRoyaleRestAPI.Application.Interfaces.Auth
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserResponse> GetUserByNameAsync(string username);
        Task<UserResponse> GetUserByIdAsync(string id);
        Task Delete(string id);
    }
}
