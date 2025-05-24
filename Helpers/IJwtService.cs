using Tasks.Models;

namespace Tasks.Helpers
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
