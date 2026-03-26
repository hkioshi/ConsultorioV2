using Microsoft.AspNetCore.Mvc;
using ConsultorioV2.Services;

namespace ConsultorioV2.Controllers
{
    [ApiController]
    [Route("api/calendar")]
    public class CalendarioController : ControllerBase
    {
        private readonly CalendarioService _calendarService;

        public CalendarioController(CalendarioService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var events = _calendarService.ExibirProximosTratamentos();

            var result = events.Select(e => new
            {
                e.Summary,
                Start = e.Start.DateTimeDateTimeOffset,
                End = e.End.DateTimeDateTimeOffset,
                Color = e.ColorId
            });

            return Ok(result);
        }
    }
}
