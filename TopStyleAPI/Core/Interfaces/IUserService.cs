using TopStyleAPI.Domain.DTO;

namespace TopStyleAPI.Core.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserDetails();
        public Task UpdateUser(UserUpdateDTO updated);
        public Task DeleteUser(string authorization);
    }
}
