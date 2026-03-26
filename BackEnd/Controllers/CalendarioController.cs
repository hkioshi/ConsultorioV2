using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioV2.Controllers
{
    [ApiController]
    [Route("api/calendario")]
    public class CalendarioController : ControllerBase
    {
        [Authorize]
        [HttpGet("hoje")]
        public async Task<IActionResult> Hoje([FromBody] string calendario)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GoogleCredential
                    .FromAccessToken(accessToken),
                ApplicationName = "ConsultorioCli"
            });

            var request = service.Events.List(calendario);
            request.TimeMin = DateTime.Today;
            request.TimeMax = DateTime.Today.AddDays(7);
            request.MaxResults = 30;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            request.Fields = "items(id,summary,start,end)";
            var events = await request.ExecuteAsync();

            return Ok(events.Items);
        }

        [Authorize]
        [HttpGet("hoje")]
        public async Task<IActionResult> Hoje()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GoogleCredential
                    .FromAccessToken(accessToken),
                ApplicationName = "ConsultorioCli"
            });

            var request = service.Events.List("primary");
            request.TimeMin = DateTime.Today;
            request.TimeMax = DateTime.Today.AddDays(7);
            request.MaxResults = 30;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            request.Fields = "items(id,summary,start,end)";
            var events = await request.ExecuteAsync();

            return Ok(events.Items);
        }
    }
}
