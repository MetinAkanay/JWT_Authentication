using JWT_Authentication.Models;

namespace JWT_Authentication.Services
{
    public interface IAuthService
    {
        public UserLoginResponse Login(UserLoginRequest request);


    }
}
