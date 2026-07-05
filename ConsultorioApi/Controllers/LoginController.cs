using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ConsultorioApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : Controller
{
    private static readonly Dictionary<string, (string email, DateTime expires)> _loginCodes = new();    // Inicia o fluxo OAuth com o Google
    [HttpGet]
    public IActionResult Login()
    {
        Console.WriteLine($"Login chamado {DateTime.Now:HH:mm:ss.fff}");
        Console.WriteLine(Environment.StackTrace);
        return Challenge(new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
            RedirectUri = "/Login/callback" // para onde redirecionar APÓS o login
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

        {
            var html = """
                       <!DOCTYPE html>
                       <html lang="pt-BR">
                       <head>
                           <meta charset="utf-8">
                           <title>Login realizado</title>
                           <style>
                               body{
                                   font-family: Arial, sans-serif;
                                   background:#1e293b;
                                   color:white;
                                   display:flex;
                                   justify-content:center;
                                   align-items:center;
                                   height:100vh;
                                   margin:0;
                               }

                               .card{
                                   background:#334155;
                                   padding:40px;
                                   border-radius:12px;
                                   text-align:center;
                                   max-width:450px;
                               }

                               h1{
                                   color:#22c55e;
                               }
                           </style>
                       </head>
                       <body>
                           <div class="card">
                               <h1>✅ Login realizado!</h1>
                               <strong>Bem-vindo!!</strong>
                               <p>Você está autenticado.</p>
                               <p>Pode fechar esta janela e voltar ao aplicativo.</p>
                           </div>
                       </body>
                       </html>
                       """;

            var code = Guid.NewGuid().ToString("N");

            _loginCodes[code] = (
                email!,
                DateTime.UtcNow.AddMinutes(5)
            );

            return Redirect($"http://127.0.0.1:54321/callback?code={code}");
        }
    }
    
    [HttpPost("auth/exchange")]
    public IActionResult Exchange([FromBody] ExchangeRequest req)
    {
        if (!_loginCodes.TryGetValue(req.Code, out var user))
            return Unauthorized();

        var token = GerarJwt(user);

        _loginCodes.Remove(req.Code);

        return Ok(new
        {
            token
        });
    }

    private string GerarJwt((string email, DateTime expires) user)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("SUA_CHAVE_SECRETA_COM_PELO_MENOS_32_CARACTERES")
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, user.email)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(12),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
public class ExchangeRequest
{
    public string Code { get; set; } = "";
}

