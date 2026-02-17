using Microsoft.AspNetCore.Mvc;

namespace ConsultorioV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultorioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API do Consultório funcionando!");
        } 
    }
}
