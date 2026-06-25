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
        if (TxtBusca.Text == "") return;
        
        if (rdbCPF.IsChecked == true)
        {
            try
            {
                // Filtrar por CPF
                if (TxtBusca.Text != null)
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
        else if (rdbId.IsChecked == true)
        {
            try
            {
                // Filtrar por ID
                if (TxtBusca.Text != null)
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
        else if (rdbNome.IsChecked == true)
            // Filtrar por Nome
            if (TxtBusca.Text != null)
                _pacienteVm.AdicionarPacientes(await _pacienteVm.BuscarPacientePorNome(TxtBusca.Text) ?? Array.Empty<Paciente>());
    } 

    private void BtnEditar_Click(object sender, RoutedEventArgs e)
    {
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
