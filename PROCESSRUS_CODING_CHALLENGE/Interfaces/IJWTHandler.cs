using PROCESSRUS_CODING_CHALLENGE.Entities.Models;

namespace PROCESSRUS_CODING_CHALLENGE.Interfaces
{
    public interface IJWTHandler
    {
        string GenerateToken(User user);
    }
}
