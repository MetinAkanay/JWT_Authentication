using JWT_Authentication.Models;

namespace JWT_Authentication.Services
{
    public interface ITokenService
    {
        public GenerateTokenResponse GenerateToken(GenerateTokenRequest request);
    }
}
