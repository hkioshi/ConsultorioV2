using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ConsultorioUI.Models;
using Microsoft.VisualBasic.FileIO;

namespace ConsultorioUI.Services;

public class LoginService
{
    public async Task<bool> CarregarTokenSalvo()
    {
        var pastaApp = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "ConsultorioUI");

        Directory.CreateDirectory(pastaApp);

        var caminhoToken = Path.Combine(pastaApp, "token.txt");

        if (!File.Exists(caminhoToken))
            return false;

        var token = await File.ReadAllTextAsync(caminhoToken);

        App.HttpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var status = await App.HttpClient.GetFromJsonAsync<Status>("Login/status");

        if (status?.IsAuthenticated == true)
            return true;

        File.Delete(caminhoToken);
        App.HttpClient.DefaultRequestHeaders.Authorization = null;

        return false;
    }

    public async Task<bool> IniciarListener()
    {
        var listener = new HttpListener();
        listener.Prefixes.Add("http://127.0.0.1:54321/");
        listener.Start();

        var ctx = await listener.GetContextAsync();

        var code = ctx.Request.QueryString["code"];
        bool sucesso = false;

        if (!string.IsNullOrEmpty(code))
        {
            var response = await App.HttpClient.PostAsJsonAsync(
                "Login/auth/exchange",
                new { Code = code });

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadFromJsonAsync<TokenResposta>();

                if (token != null)
                {
                    await File.WriteAllTextAsync("token.txt", token.Token);

                    App.HttpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token.Token);

                    sucesso = true;
                }
            }
        }

        var html = """
                   <html>
                   <body style="font-family:Arial;text-align:center;margin-top:100px;">
                       <h1>Login realizado!</h1>
                       <p>Pode fechar esta janela.</p>
                   </body>
                   </html>
                   """;

        var bytes = Encoding.UTF8.GetBytes(html);

        ctx.Response.ContentType = "text/html";
        ctx.Response.ContentLength64 = bytes.Length;
        await ctx.Response.OutputStream.WriteAsync(bytes);

        ctx.Response.Close();
        listener.Stop();

        return sucesso;
    }

    public void Logout()
    {
        if (File.Exists("token.txt"))
            File.Delete("token.txt");

        App.HttpClient.DefaultRequestHeaders.Authorization = null;
    }
    
    
    public async Task<bool> Login()
    {
        if (VerSeEstaLogado())
            return true;
        
        if (!await CarregarTokenSalvo())
        {
            var listenerTask = IniciarListener();
            Console.WriteLine("Quaq");
            // Process.Start(new ProcessStartInfo
            // {
            //     FileName = "http://www.google.com.br/",
            //     UseShellExecute =  true
            // });
        
            
            return await listenerTask;   // agora propaga o resultado real
        }

        return true;
    }

    private bool VerSeEstaLogado()
    {
        var pastaApp = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "ConsultorioUI");
        
        var caminhoToken = Path.Combine(pastaApp, "token.txt");
        
        if (!File.Exists(caminhoToken) )
            return false;

        return true;

    }
}