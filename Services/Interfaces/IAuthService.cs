using Tasks.Dtos.User;
using Tasks.Models;

namespace Tasks.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserReadDto> RegisterAsync(CreateUserDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
        int? ValidateToken(string token);
    }
}
