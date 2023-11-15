using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Interfaces.Auth;

public interface IUserRepository
{
    Task<PageList<UserModel>> GetAllAsync(int page, int pageSize);
    Task<UserModel> GetUserByNameAsync(string username);
    Task<UserModel> GetUserByIdAsync(string id);
    Task Delete(string id);
}
