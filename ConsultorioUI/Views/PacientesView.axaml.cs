using System;
using System.Linq;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ConsultorioUI.Services;
using ConsultorioUI.Models;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class PacientesView : UserControl
{
    private readonly PacienteViewModel _pacienteVm = new();
    public PacientesView()
    {
        InitializeComponent();
        DataContext = _pacienteVm;
    }

    private void BtnNovoPaciente_Click(object sender, RoutedEventArgs e) =>
        App.Navigation.Navigate("NovoPaciente");        
    
    private async void TxtBusca_TextChanged(object sender, TextChangedEventArgs e)
    {
        var texto = TxtBusca.Text.Trim();
        if (texto == "")
        {
            TxtBusca.Text = "";
            return;
        };

        // Filtrar por CPF
        if (rdbCPF.IsChecked == true)
        {
            try
            {
                if (texto.Length == 11)
                {
                    var response = await _pacienteVm.BuscarPacientePorCpf(TxtBusca.Text.Trim());
                    if (response is null) return;
                    MessageBox.Show(response.Nome);
                    _pacienteVm.Pacientes.Clear();
                    _pacienteVm.Pacientes.Add(response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // Filtrar por ID
        else if (rdbId.IsChecked == true)
        {
            try
            {
                _pacienteVm.AdicionarPaciente(await _pacienteVm.BuscarPacientePorId(TxtBusca.Text));
            }
            catch (JsonException)
            {
                _pacienteVm.Pacientes.Clear();
            }
            catch (Exception ex)
            {
                _pacienteVm.Pacientes.Clear();
                MessageBox.Show(ex.Message);
                TxtBusca.Text = "";
            }


        }
        // Filtrar por Nome
        else if (rdbNome.IsChecked == true)
        {
            try
            {
                _pacienteVm.AdicionarPacientes(await _pacienteVm.BuscarPacientePorNome(texto) ?? Array.Empty<Paciente>());
            }
            catch (JsonException)
            {
                _pacienteVm.Pacientes.Clear();
            }
            catch (Exception ex)
            {
                _pacienteVm.Pacientes.Clear();
                MessageBox.Show(ex.Message);
                TxtBusca.Text = "";
            }

        }
    } 

    private void BtnProntuario_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var id = btn?.Tag?.ToString();
        
        App.Navigation.Navigate(
            "Prontuario", 
            _pacienteVm.Pacientes.FirstOrDefault(p => p.Id.ToString() == id ));
    }
    
    private void BtnPerfil_Click(object? sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var id = btn?.Tag?.ToString();
        if (id != null) App.Navigation.Navigate("PerfilPaciente",_pacienteVm.Pacientes.FirstOrDefault(p => p.Id.ToString() == id));
    }
}
