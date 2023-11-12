﻿using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Interfaces.Auth
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel> GetUserByNameAsync(string username);
        Task<UserModel> GetUserByIdAsync(string id);
        Task Delete(string id);
    }
}
