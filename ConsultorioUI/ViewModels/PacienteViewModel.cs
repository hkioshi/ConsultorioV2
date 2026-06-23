using ConsultorioUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Permissions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia;
using ConsultorioUI.Services;

namespace ConsultorioUI.ViewModels
{
    public class PacienteViewModel
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<Paciente> Pacientes { get; set; }

        public PacienteViewModel()
        {
            _httpClient = new();
            Pacientes = [];
        }
        public async Task<Paciente?> BuscarPacientePorId(string txt)
        {
            if (!int.TryParse(txt, out _)) throw new Exception("Não é um numero");
            var response = await _httpClient.GetFromJsonAsync<Paciente>($"https://localhost:7256/Paciente/BuscarPorId/{txt}");
          
            return response;

        }

        public async Task<IEnumerable<Paciente>?> BuscarPacientePorNome(string txt) =>
            await _httpClient.GetFromJsonAsync<List<Paciente>>($"https://localhost:7256/Paciente/BuscarPorNome/{txt}");

        public async Task<Paciente?> BuscarPacientePorCpf(string txt) =>
            await _httpClient.GetFromJsonAsync<Paciente>($"https://localhost:7256/Paciente/BuscarPorCPF/{txt}");


        public bool Validar(Visual visual, Paciente paciente)
        {
            if (string.IsNullOrWhiteSpace(paciente.Nome))
            {
                MessageBox.Show(visual,"O campo Nome é obrigatório.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(paciente.Cpf) || paciente.Cpf.Length != 14)
            {
                MessageBox.Show(visual,"CPF inválido ou não informado.");
                return false;
            }
            if (paciente.DataNascimento == DateTime.MinValue )
            {
                MessageBox.Show(visual,"Informe a data de nascimento.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(paciente.Telefone) || paciente.Telefone.Length < 14)
            {
                MessageBox.Show(visual,"Telefone inválido ou não informado.");
                return false;
            }
            return true;
        }
        public bool Validar(Visual visual, PacienteUpdateDTO paciente)
        {
            if (string.IsNullOrWhiteSpace(paciente.Nome))
            {
                MessageBox.Show(visual,"O campo Nome é obrigatório.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(paciente.Cpf) || paciente.Cpf.Length < 14)
            {
                MessageBox.Show(visual,"CPF inválido ou não informado.");
                return false;
            }
            if (paciente.DataNascimento == DateTime.MinValue )
            {
                MessageBox.Show(visual,"Informe a data de nascimento.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(paciente.Telefone) || paciente.Telefone.Length < 14)
            {
                MessageBox.Show(visual,"Telefone inválido ou não informado.");
                return false;
            }
            return true;
        }
        public async Task<bool> SalvarNovo(Paciente paciente)
        {
            const string urlPaciente   = "https://localhost:7256/Paciente";
            const string urlProntuario = "https://localhost:7256/Prontuario";
            using HttpClient client = new();

            var response = await client.PostAsync(
                urlPaciente,
                new StringContent(JsonSerializer.Serialize(paciente), Encoding.UTF8, "application/json"));
            
            if(!response.IsSuccessStatusCode) return false; 
            
            var pacienteCriado = await response.Content.ReadFromJsonAsync<Paciente>();

            response = await client.PostAsync(
                urlProntuario,
                new StringContent(
                    JsonSerializer.Serialize(new ProntuarioId { PacienteId = pacienteCriado!.Id }),
                    Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;

        }
        
        public async Task<bool> SalvarAlteracao(PacienteUpdateDTO paciente, string id)
        {
            
            const string urlPaciente   = "https://localhost:7256/Paciente";
            using HttpClient client = new();
            
            var response = await client.PutAsJsonAsync(
                $"{urlPaciente}/{id}",
                paciente);

            return response.IsSuccessStatusCode;
        }
    }
}
