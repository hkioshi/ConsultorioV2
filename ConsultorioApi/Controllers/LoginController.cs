using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : Controller
{
    // Inicia o fluxo OAuth com o Google
    [HttpGet]
    public IActionResult Login()
    {
        return Challenge(new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
            RedirectUri = "/Login/callback"  // para onde redirecionar APÓS o login
        }, "Google");
    }
 
    // GET /auth/logout
    // Remove o cookie de sessão e retorna 204
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("Cookies");
        return NoContent();
    }
 
    // GET /auth/status
    // Retorna se o usuário está autenticado e, se sim, suas informações básicas
    [HttpGet("status")]
    public IActionResult Status()
    {
        if (User.Identity?.IsAuthenticated != true)
            return Ok(new { IsAuthenticated = false });
 
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var nome = User.Identity?.Name;
 
        return Ok(new
        {
            IsAuthenticated = true,
            Nome = nome,
            Email = email
        });
    }
 
    // GET /auth/callback
    // RedirectUri de retorno após autenticação bem-sucedida no Google
    [HttpGet("callback")]
    public IActionResult Callback()
    {
        if (User.Identity?.IsAuthenticated != true)
            return Unauthorized();
 
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var nome = User.Identity?.Name;
 
        return Ok(new
        {
            Nome = nome,
            Email = email
        });
    }
}