using JWT_Authentication.Models;

namespace JWT_Authentication.Services
{
    public class AuthService : IAuthService
    {
        public UserLoginResponse Login(UserLoginRequest request)
        {
            UserLoginResponse response = new UserLoginResponse();
            if (request==null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                //login olmaya gelen kullanıcı adı veya şifreyi boş girmiştir
                throw new ArgumentNullException("Kullanıcı adı ve şifre boş olamaz");

            }
            if (request.Username=="root" && request.Password=="1010")
            {
                response = new UserLoginResponse
                {
                    AuthToken = string.Empty,
                    IsAuthenticated = true,
                    TokenExpireDate = DateTime.Now.AddHours(3)
                };
            }
            else
            {
                response = new UserLoginResponse
                {
                    AuthToken = string.Empty,
                    IsAuthenticated = false,
                    TokenExpireDate = new DateTime()
                };
                
            }
            return response;
        }
    }
}
