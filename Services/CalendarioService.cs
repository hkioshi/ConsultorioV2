using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
namespace ConsultorioV2.Services;
public class CalendarioService
{
    private readonly CalendarService _service;

    public CalendarioService()
    {
        var credential = GoogleCredential
            .FromFile("credentials.json")
            .CreateScoped(CalendarService.Scope.CalendarReadonly);

        _service = new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "ConsultorioApp"
        });
    }

    public IList<Google.Apis.Calendar.v3.Data.Event> ExibirProximosTratamentos()
    {
        DateTime hoje = DateTime.Today;
        var request = _service.Events.List("draceliaodonto@gmail.com");
        request.TimeMinDateTimeOffset = new DateTime(hoje.Year, hoje.Month, hoje.Day, 7, 0, 0);
        request.TimeMaxDateTimeOffset = new DateTime(hoje.Year,hoje.Month, hoje.Day, 22,0,0);
        request.ShowDeleted = false;
        request.SingleEvents = true;
        request.MaxResults = 30;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        return request.Execute().Items;
    }
}