using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConsultorioUI.Models;

namespace ConsultorioUI.Services;

public class DatabaseService
{
    private static readonly HttpClient HttpClient = new HttpClient();

    public static async Task<Paciente?> BuscarPacientePorId(string txt) =>
        await HttpClient.GetFromJsonAsync<Paciente>($"https://localhost:7256/Paciente/BuscarPorId/{txt}");

    public static async Task<IEnumerable<Paciente>?> BuscarPacientePorNome(string txt) =>
        await HttpClient.GetFromJsonAsync<List<Paciente>>($"https://localhost:7256/Paciente/BuscarPorNome/{txt}");
    
    public static async Task<Paciente?> BuscarPacientePorCpf(string txt) =>
        await HttpClient.GetFromJsonAsync<Paciente>($"https://localhost:7256/Paciente/BuscarPorCPF/{txt}");

    public static async Task<bool> SalvarNovo(Paciente paciente)
    {
        const string urlPaciente = "https://localhost:7256/Paciente";
        const string urlProntuario = "https://localhost:7256/Prontuario";

        var response = await HttpClient.PostAsync(
            urlPaciente,
            new StringContent(JsonSerializer.Serialize(paciente), Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode) return false;

        var pacienteCriado = await response.Content.ReadFromJsonAsync<Paciente>();

        response = await HttpClient.PostAsync(
            urlProntuario,
            new StringContent(
                JsonSerializer.Serialize(new ProntuarioId { PacienteId = pacienteCriado!.Id }),
                Encoding.UTF8, "application/json"));

        return response.IsSuccessStatusCode;
    }

    public static async Task<bool> SalvarAlteracao(PacienteUpdateDTO paciente, string id)
    {
        const string urlPaciente = "https://localhost:7256/Paciente";
        using HttpClient client = new();

        var response = await client.PutAsJsonAsync(
            $"{urlPaciente}/{id}",
            paciente);

        return response.IsSuccessStatusCode;
    }
}