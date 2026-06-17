using System;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Selection;
using Avalonia.Interactivity;
using ConsultorioUI.Services;
using ConsultorioUI.Models;
using ConsultorioUI.ViewModels;

namespace ConsultorioUI.Views;

public partial class PacientesView : UserControl
{
    public event Action<string> OnNavigate;

    PacienteViewModel _PacienteVM;
    private MainWindow _mainWindow;
    public PacientesView(MainWindow mainWindow)
    {
        InitializeComponent();
        _mainWindow = mainWindow;
        _PacienteVM = new();
        DataContext = _PacienteVM;
    }

    private void BtnNovoPaciente_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new NovoPacienteDialog();
        dialog.ShowDialog( TopLevel.GetTopLevel(this) as Window);

        // PacienteSalvo será null se o usuário cancelou
        if (dialog.PacienteSalvo != null)
        {
            var paciente = dialog.PacienteSalvo;
            // salvar no banco, atualizar lista...
        }
    }

    private async void TxtBusca_TextChanged(object sender, TextChangedEventArgs e)
    {
        //TODO: Formatar o texto quando pesquisar
        if (TxtBusca.Text == "") return;



        if (rdbCPF.IsChecked == true)
        {
            try
            {
                // Filtrar por CPF
                var response = await _PacienteVM.BuscarPacientePorCpf(TxtBusca.Text.Trim());
                if (response is null) return;
                MessageBox.Show(this,response.Nome);
                _PacienteVM.Pacientes.Clear();
                _PacienteVM.Pacientes.Add(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.Message);
            }

        }
        else if (rdbId.IsChecked == true)
        {
            try
            {
                // Filtrar por ID
                var response = await _PacienteVM.BuscarPacientePorId(TxtBusca.Text);
                if (response is null) return;
                _PacienteVM.Pacientes.Clear();
                _PacienteVM.Pacientes.Add(response);
            }
            catch (JsonException ex)
            {
                _PacienteVM.Pacientes.Clear();
            }
            catch (Exception ex)
            {
                _PacienteVM.Pacientes.Clear();
                MessageBox.Show(this,ex.Message);
                TxtBusca.Text = "";
            }


        }
        else if (rdbNome.IsChecked == true)
        {
            // Filtrar por Nome
            var response = await _PacienteVM.BuscarPacientePorNome(TxtBusca.Text);
            if (response is null) return;
            _PacienteVM.Pacientes.Clear();


            foreach (Paciente i in response) _PacienteVM.Pacientes.Add(i);

        }
    } 
    //TODO: Fazer Editar
    //TODO: Design Editar
    private void BtnEditar_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var id = btn?.Tag?.ToString();

        // EditarView editar = new(id);
        // _mainWindow.MainContent.Content = new EditarView(id);
    }
    //TODO: Fazer Prontuario
    //TODO: Fazer Odontograma
    //TODO: Design Prontuario
    private void BtnProntuario_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var id = btn?.Tag?.ToString();

        ProntuarioView prontuario = new(id);
        _mainWindow.MainContent.Content = new ProntuarioView(id);
        
    }
    
    //TODO: Design Perfil

    private void BtnPerfil_Click(object? sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var id = btn?.Tag?.ToString();

        PacientePerfilView perfil = new(id);
        _mainWindow.MainContent.Content = new PacientePerfilView(id);
    }
}
