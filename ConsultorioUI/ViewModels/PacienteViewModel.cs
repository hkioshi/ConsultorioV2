using ConsultorioUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

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



    }
}
