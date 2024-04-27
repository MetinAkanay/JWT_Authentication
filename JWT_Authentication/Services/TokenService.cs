using JWT_Authentication.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Authentication.Services
{

    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public GenerateTokenResponse GenerateToken(GenerateTokenRequest request)
        {
            var dateTime = DateTime.UtcNow;
            // secret bilgisi, token oluşturulurken kullanılır. Token bir şifre ile oluşturulur ve bir şifre ile çözülür.
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]));

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _configuration["AppSettings:ValidIssuer"],
                audience: _configuration["AppSettings:ValidAudience"],
                    claims: new List<Claim>
                    {
                        // Token içerisine eklemek istediğin bilgileri burada ekleyebilirsin.
                        // Token içerisine önemli bilgiler eklenmemelidir. Çünkü JWT dünyası token içerisindeki verilerin görünmememsine değil değiştirilememesine odaklanmıştır.
                        new Claim("username", request.Username)
                    },

                    // Oluşturduğun token'ın bir süre sonra aktif olmasını istersen notBefore kullanabilirsin.
                    notBefore: DateTime.Now,
                    expires: dateTime.Add(TimeSpan.FromMinutes(600)),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));


            return new GenerateTokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpireDate = dateTime.Add(TimeSpan.FromMinutes(600))
            };
        }
    }
}
