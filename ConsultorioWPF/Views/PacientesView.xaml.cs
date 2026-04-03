using System.Windows;
using System.Windows.Controls;

namespace ConsultorioWPF.Views;

public partial class PacientesView : UserControl
{
    public PacientesView() => InitializeComponent();
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

    private void TxtBusca_TextChanged(object sender, TextChangedEventArgs e)
    {
        // TODO: Filtrar lista de pacientes conforme o texto digitado
        // Exemplo com binding/ViewModel: ViewModel.FiltrarPacientes(TxtBusca.Text);
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