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
        
        public ObservableCollection<Paciente> Pacientes { get; set; }

        public PacienteViewModel()
        {
            Pacientes = [];
        }

        public async Task<Paciente?> BuscarPacientePorId(string txt)
        {
            if (!int.TryParse(txt, out _)) throw new Exception("Não é um numero");
            return await DatabaseService.BuscarPacientePorId(txt);
        }

        public async Task<IEnumerable<Paciente>?> BuscarPacientePorNome(string txt) =>
            await DatabaseService.BuscarPacientePorNome(txt);

        public async Task<Paciente?> BuscarPacientePorCpf(string txt) =>
            await DatabaseService.BuscarPacientePorCpf(txt);

        public async Task<bool> SalvarNovo(Paciente paciente) =>
             await DatabaseService.SalvarNovo(paciente);
        
        public async Task<bool> SalvarAlteracao(PacienteUpdateDTO paciente, string id) =>
            await DatabaseService.SalvarAlteracao(paciente, id);

        public void AdicionarPacientes(IEnumerable<Paciente?> response)
        {
            Pacientes.Clear();
            foreach (Paciente? i in response)
                if (i != null)
                    Pacientes.Add(i);
        }

        public void AdicionarPaciente(Paciente? paciente)
        {
            Pacientes.Clear();
            if (paciente != null)
                Pacientes.Add(paciente);
        }
    }
}