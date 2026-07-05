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

    public static async Task<Paciente?> BuscarPacientePorId(string txt) =>
        await App.HttpClient.GetFromJsonAsync<Paciente>($"Paciente/BuscarPorId/{txt}");

    public static async Task<IEnumerable<Paciente>?> BuscarPacientePorNome(string txt) =>
        await App.HttpClient.GetFromJsonAsync<List<Paciente>>($"Paciente/BuscarPorNome/{txt}");
    
    public static async Task<Paciente?> BuscarPacientePorCpf(string txt) =>
        await App.HttpClient.GetFromJsonAsync<Paciente>($"Paciente/BuscarPorCPF/{txt}");

    public static async Task<bool> SalvarNovo(Paciente paciente)
    {
        const string urlPaciente = "Paciente";
        const string urlProntuario = "Prontuario";

        var response = await App.HttpClient.PostAsync(
            urlPaciente,
            new StringContent(JsonSerializer.Serialize(paciente), Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode) return false;

        var pacienteCriado = await response.Content.ReadFromJsonAsync<Paciente>();

        response = await App.HttpClient.PostAsync(
            urlProntuario,
            new StringContent(
                JsonSerializer.Serialize(new ProntuarioId { PacienteId = pacienteCriado!.Id }),
                Encoding.UTF8, "application/json"));

        return response.IsSuccessStatusCode;
    }

    public static async Task<bool> SalvarAlteracao(PacienteUpdateDTO paciente, string id)
    {
        const string urlPaciente = "Paciente";

        var response = await App.HttpClient.PutAsJsonAsync(
            $"{urlPaciente}/{id}",
            paciente);

        return response.IsSuccessStatusCode;
    }
    public static async Task<int> BuscarIdProntuarioPorIdPaciente(string id) =>
        await App.HttpClient.GetFromJsonAsync<int>($"Prontuario/IdProntuarioPorIdPaciente/{id}");


    public static async Task<bool> SalvarNovoTratamento(CreateTratamentoDto novoTratamento)
    {
        var response = await App.HttpClient.PostAsJsonAsync(
            "Tratamentos",
            novoTratamento);

        return response.IsSuccessStatusCode;
    }
    public static async Task<List<Tratamento>?> ExibirTratamentos(int id) =>
        await App.HttpClient.GetFromJsonAsync<List<Tratamento>>($"Tratamentos/AcharTratametosDoPaciente/{id}");
    
    public static async Task<bool> SalvarAlteracaoTratamento(Tratamento tratamento, int id)
    {
        var response = await App.HttpClient.PutAsJsonAsync(
            $"Tratamentos/{id}",
            tratamento);

        return response.IsSuccessStatusCode;
    }

    public static async Task<Tratamento?> BuscarTratamento(string? id) =>
        await App.HttpClient.GetFromJsonAsync<Tratamento>($"Tratamentos/{id}");
    public static async Task<bool> ExcluirTratamento(int id)
    {
        var response = await App.HttpClient.DeleteAsync($"/Tratamentos/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task ExcluirPaciente(int id)
    {
        
        //Todo: responsePagamentos
        var responsePaciente = await App.HttpClient.DeleteAsync($"/Paciente/{id}");
        
        
        bool response;
        if (responsePaciente.IsSuccessStatusCode) ;

    }

    
    
}