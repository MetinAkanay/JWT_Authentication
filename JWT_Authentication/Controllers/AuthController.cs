using JWT_Authentication.Models;
using JWT_Authentication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        // Routing vermemize gerek yok controller içerisindeki tek bir action olduğu için controller seviyesinde post dediğimizde bu action çalışacaktır.   
        [HttpPost]
        public IActionResult LoginUser(UserLoginRequest request)
        {
            var result = _authService.Login(request);

            if(result.IsAuthenticated)
            {
                return Ok(result);
            }
            else
            {
                // Girilen kullanıcı adı ve şifre yanlış ise unauthorized dönecektir.
                return Unauthorized(result);
            }
        }
    }
}
