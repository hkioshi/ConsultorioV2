using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
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
    public async Task<IActionResult> Hoje(string calendario)
    {
        var inicio = DateTimeOffset.Now.Date;
        var fim = inicio.AddDays(1);

        var eventos = await BuscarEventos(calendario, inicio, fim);

        return Ok(MapearEventos(eventos));
    }

    [Authorize]
    [HttpGet("{calendario}/semana")]
    public async Task<IActionResult> Semana(string calendario)
    {
        var inicio = DateTimeOffset.Now.Date;
        var fim = inicio.AddDays(7);

        var eventos = await BuscarEventos(calendario, inicio, fim);

        return Ok(MapearEventos(eventos));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Calendarios()
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        var service = new CalendarService(new BaseClientService.Initializer
        {
            HttpClientInitializer = GoogleCredential.FromAccessToken(accessToken),
            ApplicationName = "ConsultorioCli"
        });

        var request = service.CalendarList.List();
        var result = await request.ExecuteAsync();

        return Ok(result.Items.Select(c => new
        {
            Nome = c.Summary, c.Id
        }));
    }
    
    private async Task<IList<Event>> BuscarEventos(
        string calendario,
        DateTimeOffset inicio,
        DateTimeOffset fim)
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        var service = new CalendarService(new BaseClientService.Initializer
        {
            HttpClientInitializer = GoogleCredential.FromAccessToken(accessToken),
            ApplicationName = "ConsultorioCli"
        });

        var request = service.Events.List(calendario);
        request.TimeMinDateTimeOffset = inicio;
        request.TimeMaxDateTimeOffset = fim;
        request.MaxResults = 50;
        request.SingleEvents = true;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
        request.Fields = "items(id,summary,start,end,colorId)";

        var events = await request.ExecuteAsync();

        return events.Items;
    }
    
    private static object MapearEventos(IList<Event> eventos)
    {
        return eventos.Select(e => new
        {
            e.Id,
            Titulo = e.Summary,
            Inicio = e.Start.DateTimeDateTimeOffset ?? DateTimeOffset.Parse(e.Start.Date),
            Fim = e.End.DateTimeDateTimeOffset ?? DateTimeOffset.Parse(e.End.Date),
            Cor = e.ColorId
        });
    }
}