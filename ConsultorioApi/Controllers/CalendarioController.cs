using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioApi.Controllers;

[Authorize]
[ApiController]
[Route("api/calendario")]
public class CalendarioController : ControllerBase
{
    [Authorize]
    [HttpGet("{calendario}/hoje")]
    public async Task<IActionResult> HojeNoCalendario(string calendario)
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        var service = new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = GoogleCredential
                .FromAccessToken(accessToken),
            ApplicationName = "ConsultorioCli"
        });

        var request = service.Events.List(calendario);
        //request.TimeMaxDateTimeOffset = DateTime.Today;
        //request.TimeMinDateTimeOffset = DateTime.Today.AddDays(7);
        request.MaxResults = 30;
        request.SingleEvents = true;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
        request.Fields = "items(id,summary,start,end)";
        var events = await request.ExecuteAsync();

        return Ok(events.Items.Select(e => new
        {
            Id = e.Id,
            Titulo = e.Summary, 
            Inicio = e.Start.DateTimeDateTimeOffset,
            Fim = e.End.DateTimeDateTimeOffset
        }));
    }

    [Authorize]
    [HttpGet("hoje")]
    public async Task<IActionResult> HojeNoCalendarioPrincipal()
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        var service = new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = GoogleCredential
                .FromAccessToken(accessToken),
            ApplicationName = "ConsultorioCli"
        });

        var request = service.Events.List("primary");
        request.TimeMaxDateTimeOffset = DateTime.Today;
        request.TimeMinDateTimeOffset = DateTime.Today.AddDays(7);
        request.MaxResults = 30;
        request.SingleEvents = true;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
        request.Fields = "items(id,summary,start,end)";
        var events = await request.ExecuteAsync();

        return Ok(events.Items.Select(e => new
        {
            Id = e.Id,
            Titulo = e.Summary,
            Inicio = e.Start.DateTimeDateTimeOffset,
            Fim = e.End.DateTimeDateTimeOffset
        }));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Calendarios()
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        var service = new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = GoogleCredential.FromAccessToken(accessToken),
            ApplicationName = "ConsultorioCli"
        });

        var request = service.CalendarList.List();
        var result = await request.ExecuteAsync();

        return Ok(result.Items.Select(c => new
        {
            Nome = c.Summary,
            Id = c.Id
        }));
    }
}
