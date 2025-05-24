using Tasks.Dtos.User;
using Tasks.Models;

namespace Tasks.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserReadDto> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
        Task<User> GetUserByUsernameAsync(string username);
    }
}

