using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static JWT_Authentication.Services.AdventureWorksService;

namespace JWT_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventureWorksController : ControllerBase
    {
        private IAdventureWorksService _adventureWorksService;
        public AdventureWorksController(IAdventureWorksService adventureWorksService)
        {
            _adventureWorksService = adventureWorksService;
        }

        [HttpPost]
        [Route("Color")]
        public IActionResult GetProductByColor(string color)
        {
            var result = _adventureWorksService.GetProductByColor(color);
            return Ok(result);
        }
        // Bu action sadece authorize olan kullanıcılar tarafından erişilebilir.
        [Authorize]
        [HttpGet]
        [Route("Person")]
        public IActionResult GetPerson()
        {
            var result = _adventureWorksService.GetPerson();
            return Ok(result);
        }
    }
}
