using System.Windows;
using System.Windows.Controls;
using ConsultorioWPF.Models;
using ConsultorioWPF.ViewModels;
using System.Text.Json;
namespace ConsultorioWPF.Views;

public partial class PacientesView : UserControl
{
    PacienteViewModel _PacienteVM;
    public PacientesView()
    {
        InitializeComponent();
        _PacienteVM = new();
        DataContext = _PacienteVM;
    }

    private void BtnNovoPaciente_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Abrir janela/dialog de cadastro de novo paciente
        var dialog = new NovoPacienteDialog { Owner = Window.GetWindow(this) };
        if (dialog.ShowDialog() == true)
        {
            var paciente = dialog.PacienteSalvo;
            // salvar no banco, atualizar lista...
        }
    }

    private async void TxtBusca_TextChanged(object sender, TextChangedEventArgs e)
    {
        // TODO: Filtrar lista de pacientes conforme o texto digitado
        if (TxtBusca.Text == "") return;



        if (rdbCPF.IsChecked == true)
        {
            try
            {
                // Filtrar por CPF
                var response = await _PacienteVM.BuscarPacientePorCPF(TxtBusca.Text);
                if (response is null) return;
                MessageBox.Show(response.Nome);
                _PacienteVM.Pacientes.Clear();
                _PacienteVM.Pacientes.Add(response);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
    private void BtnEditar_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var id = btn?.Tag?.ToString();
        // TODO: Abrir tela de edição para o paciente com id
        MessageBox.Show($"Editar paciente ID: {id}");
    }

    private void BtnProntuario_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var id = btn?.Tag?.ToString();
        // TODO: Abrir prontuário do paciente
        MessageBox.Show($"Abrir prontuário do paciente ID: {id}");
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {

    }
}