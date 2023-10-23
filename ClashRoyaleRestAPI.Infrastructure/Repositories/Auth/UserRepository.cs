using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Application.Auth.User;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Exceptions.Auth;
using ClashRoyaleRestAPI.Domain.Exceptions.Models;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Auth
{
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

        public async Task<UserResponse> GetUserByNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username)
                ?? throw new UsernameNotFoundException();

            var role = (await _userManager.GetRolesAsync(user)).First();

            return UserResponse.Create(user.Id, user.UserName!, role);
        }
        public async Task<UserResponse> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id)
                ?? throw new IdNotFoundException();

            var role = (await _userManager.GetRolesAsync(user)).First();

            return UserResponse.Create(user.Id, user.UserName!, role);
        }
        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            if (_context.Users == null) throw new ModelNotFoundException<IdentityUser>();

            return await _context.Users
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task Delete(string id)
        {
            var identUser = await _userManager.FindByIdAsync(id)
                ?? throw new IdNotFoundException();

            await _userManager.DeleteAsync(identUser);

            await _context.SaveChangesAsync();
        }

    }
}
