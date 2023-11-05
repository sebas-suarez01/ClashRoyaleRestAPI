using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleRestAPI.Application.Auth.User;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Exceptions.Auth;
using ClashRoyaleRestAPI.Domain.Exceptions.Models;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models
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
        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            if (_context.Users == null) throw new ModelNotFoundException(nameof(IdentityUser));

            return await _context.Users
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task Delete(string id)
        {
            var identUser = await _userManager.FindByIdAsync(id)
                ?? throw new IdNotFoundException<string>(id);

            await _userManager.DeleteAsync(identUser);

            await _context.SaveChangesAsync();
        }

    }
}
