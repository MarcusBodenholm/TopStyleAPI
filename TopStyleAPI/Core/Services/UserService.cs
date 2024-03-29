using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using TopStyleAPI.Core.Authorization.Interface;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Domain.DTO;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<Customer> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenLifeTimeManager _tokenLifeTimeManager;

        public UserService(IHttpContextAccessor context, UserManager<Customer> userManager, IMapper mapper, ITokenLifeTimeManager tokenLifeTimeManager)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _tokenLifeTimeManager = tokenLifeTimeManager;
        }

        public async Task<UserDTO> GetUserDetails()
        {
            var user = await GetCurrentUser(false);
            var result = _mapper.Map<UserDTO>(user);
            return result;
        }
        public async Task UpdateUser(UserUpdateDTO updated)
        {
            var user = await GetCurrentUser(true);
            user.Email = updated.Email;
            user.PhoneNumber = updated.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Unable to update user.");
            }
        }
        public async Task DeleteUser(string authorization)
        {
            var user = await GetCurrentUser(true);
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Unable to delete user.");
            }
            string bearerToken = authorization.Replace("Bearer ", string.Empty, StringComparison.InvariantCultureIgnoreCase);
            _tokenLifeTimeManager.SignOut(new JwtSecurityToken(bearerToken));
        }
        private async Task<Customer> GetCurrentUser(bool tracking)
        {
            var httpUser = _context.HttpContext?.User?.Identity?.Name;
            if (httpUser == null)
            {
                throw new Exception("User not defined");
            }
            var user = tracking ?
                await _userManager.Users
                .Include(u => u.Orders)
                .SingleOrDefaultAsync(u => u.UserName == httpUser) :
                await _userManager.Users
                .Include(u => u.Orders)
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.UserName == httpUser);
            if (user == null) new Exception("User not found.");
            return user;
        }

    }
}
