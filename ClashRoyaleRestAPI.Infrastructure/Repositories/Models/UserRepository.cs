using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Exceptions.Auth;
using ClashRoyaleRestAPI.Domain.Exceptions.Models;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models;

internal sealed class UserRepository : IUserRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ClashRoyaleDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(UserManager<IdentityUser> userManager, ClashRoyaleDbContext context, IMapper mapper)
    {
        _userManager = userManager;
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserModel> GetUserByNameAsync(string username)
    {
        var user = await _userManager.FindByNameAsync(username)
            ?? throw new UsernameNotFoundException();

        var role = (await _userManager.GetRolesAsync(user)).First();

        return UserModel.Create(user.Id, user.UserName!, user.PasswordHash!, role);
    }
    public async Task<UserModel> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id)
            ?? throw new IdNotFoundException<string>(id);

        var role = (await _userManager.GetRolesAsync(user)).First();

        return UserModel.Create(user.Id, user.UserName!, user.PasswordHash!, role);
    }
    public async Task<PageList<UserModel>> GetAllAsync(int page, int pageSize)
    {
        if (_context.Users == null) throw new ModelNotFoundException(nameof(IdentityUser));

        var users = _context.Users
                    .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                    .AsQueryable();

        await Task.CompletedTask;

        return PageList<UserModel>.Create(users, page, pageSize);
    }
    public async Task Delete(string id)
    {
        var identUser = await _userManager.FindByIdAsync(id)
            ?? throw new IdNotFoundException<string>(id);

        await _userManager.DeleteAsync(identUser);
    }
    public async Task UpdateRole(string id, string role)
    {
        var identUser = await _userManager.FindByIdAsync(id)
            ?? throw new IdNotFoundException<string>(id);

        var currentRole = (await _userManager.GetRolesAsync(identUser)).First();

        await _userManager.RemoveFromRoleAsync(identUser, currentRole);

        await _userManager.AddToRoleAsync(identUser, role);
    }
}
