using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        // Inicia o login com Google
        [HttpGet("signIn")]
        public IActionResult Login()
        {
            // Não precisa setar RedirectUri manualmente; o middleware cuida disso
            return Challenge(new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),

                RedirectUri = "/Login/userInfo"
            }, "Google");
        }

        // Logout
        [HttpGet("signOut")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return NoContent();
        }

        [HttpGet("userInfo")]
        public IActionResult UserInfo()
        {
            if (User.Identity?.IsAuthenticated != true)
                return Unauthorized();

            var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            var nome = User.Identity?.Name;

            return Ok(new
            {
                Nome = nome,
                Email = email
            });
        }
    }
}