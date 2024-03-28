using TopStyleAPI.Core.Interfaces;

namespace TopStyleAPI.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _context;

        public UserService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public async Task<string> GetName()
        {
            var result = string.Empty;
            if (_context.HttpContext is not null)
            {
                result = _context.HttpContext.User?.Identity?.Name;
            }
            return result;
        }
    }
}
