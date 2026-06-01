using SwimmingSchoolApi.Models;

namespace SwimmingSchoolApi.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
