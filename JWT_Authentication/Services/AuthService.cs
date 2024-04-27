using JWT_Authentication.Models;

namespace JWT_Authentication.Services
{
    public class AuthService : IAuthService
    {
        private ITokenService _tokenservice { get; set; }
        public AuthService(ITokenService tokenservice)
        {
            _tokenservice = tokenservice;
        }
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
                var generateTokenResult = _tokenservice.GenerateToken(new GenerateTokenRequest { Username = request.Username });
                response = new UserLoginResponse
                {
                    // Tokenservice tarafından üretiken token değerini AuthToken kısmına verelim
                    AuthToken = generateTokenResult.Token,
                    IsAuthenticated = true,
                    TokenExpireDate = generateTokenResult.TokenExpireDate
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
