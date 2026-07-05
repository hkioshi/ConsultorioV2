using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ConsultorioUI.Models;

namespace ConsultorioUI.Services;

public class LoginService
{
    private static readonly HttpClient _httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7256/")
    };
    
    public async Task<bool> VerificarConexao()
    {
        var response = await _httpClient.GetFromJsonAsync<Status>("/Login/status");
        if (response is null)
            throw new NullReferenceException();
        return response.IsAuthenticated ; 
    }
    public async Task IniciarListener()
    {
        var listener = new HttpListener();
        listener.Prefixes.Add("http://127.0.0.1:54321/");
        listener.Start();

        Console.WriteLine("Listener iniciado.");

        while (true)
        {
            var ctx = await listener.GetContextAsync();

            Console.WriteLine(ctx.Request.RawUrl);

            var html = """
                       <html>
                       <body>
                           <h1>O Avalonia recebeu a requisição!</h1>
                       </body>
                       </html>
                       """;

            var bytes = Encoding.UTF8.GetBytes(html);

            ctx.Response.ContentType = "text/html";
            ctx.Response.ContentLength64 = bytes.Length;

            await ctx.Response.OutputStream.WriteAsync(bytes);
            ctx.Response.Close();
        }
    }
    
}