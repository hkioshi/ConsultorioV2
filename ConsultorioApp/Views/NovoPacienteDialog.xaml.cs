using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using ConsultorioApp.Models; // ajuste para o namespace do seu projeto

namespace ConsultorioApp.Views;

public partial class NovoPacienteDialog : Window
{
    // Propriedade com o paciente montado após salvar
    public Paciente PacienteSalvo { get; private set; }
    public NovoPacienteDialog() => InitializeComponent();

    // ══════════════════════════════════════════
    // NAVEGAÇÃO ENTRE TABS
    // ══════════════════════════════════════════
    private void Tab_Checked(object sender, RoutedEventArgs e)
    {
        if (TabPessoal == null) return; // ainda inicializando

        var rb = sender as RadioButton;
        var tag = rb?.Tag?.ToString();

        TabPessoal.Visibility  = Visibility.Collapsed;
        TabContato.Visibility  = Visibility.Collapsed;
        TabExtra.Visibility    = Visibility.Collapsed;

        switch (tag)
        {
            case "TabPessoal": TabPessoal.Visibility = Visibility.Visible; break;
            case "TabContato": TabContato.Visibility = Visibility.Visible; break;
            case "TabExtra":   TabExtra.Visibility   = Visibility.Visible; break;
        }
    }

    // ══════════════════════════════════════════
    // MÁSCARAS
    // ══════════════════════════════════════════
    private void TxtCpf_TextChanged(object sender, TextChangedEventArgs e)
    {
        var tb = sender as TextBox;
        if (tb == null) return;
        var digits = Regex.Replace(tb.Text, @"\D", "");
        if (digits.Length > 11) digits = digits.Substring(0, 11);

        string masked = digits;
        if (digits.Length >= 4)  masked = digits.Substring(0, 3) + "." + digits.Substring(3);
        if (digits.Length >= 7)  masked = masked.Substring(0, 7) + "." + digits.Substring(6);
        if (digits.Length >= 10) masked = masked.Substring(0, 11) + "-" + digits.Substring(9);

        if (tb.Text != masked)
        {
            tb.TextChanged -= TxtCpf_TextChanged;
            tb.Text = masked;
            tb.CaretIndex = masked.Length;
            tb.TextChanged += TxtCpf_TextChanged;
        }
    }

    private void TxtTelefone_TextChanged(object sender, TextChangedEventArgs e)
    {
        var tb = sender as TextBox;
        if (tb == null) return;
        var digits = Regex.Replace(tb.Text, @"\D", "");
        if (digits.Length > 11) digits = digits.Substring(0, 11);

        string masked = digits;
        if (digits.Length >= 1)  masked = "(" + digits;
        if (digits.Length >= 3)  masked = "(" + digits.Substring(0, 2) + ") " + digits.Substring(2);
        if (digits.Length >= 8)
        {
            int splitAt = digits.Length == 11 ? 7 : 6;
            masked = "(" + digits.Substring(0, 2) + ") "
                   + digits.Substring(2, splitAt) + "-"
                   + digits.Substring(2 + splitAt);
        }

        if (tb.Text != masked)
        {
            tb.TextChanged -= TxtTelefone_TextChanged;
            tb.Text = masked;
            tb.CaretIndex = masked.Length;
            tb.TextChanged += TxtTelefone_TextChanged;
        }
    }

    private void TxtCep_TextChanged(object sender, TextChangedEventArgs e)
    {
        var tb = sender as TextBox;
        if (tb == null) return;
        var digits = Regex.Replace(tb.Text, @"\D", "");
        if (digits.Length > 8) digits = digits.Substring(0, 8);

        string masked = digits.Length >= 6
            ? digits.Substring(0, 5) + "-" + digits.Substring(5)
            : digits;

        if (tb.Text != masked)
        {
            tb.TextChanged -= TxtCep_TextChanged;
            tb.Text = masked;
            tb.CaretIndex = masked.Length;
            tb.TextChanged += TxtCep_TextChanged;
        }
    }

    // ══════════════════════════════════════════
    // BUSCA DE CEP (ViaCEP)
    // ══════════════════════════════════════════
    private async void BtnBuscarCep_Click(object sender, RoutedEventArgs e)
    {
        var cep = Regex.Replace(TxtCep.Text, @"\D", "");
        if (cep.Length != 8)
        {
            MessageBox.Show("CEP inválido. Digite os 8 dígitos.", "Atenção",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
            using var http = new System.Net.Http.HttpClient();
            var json = await http.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (json.Contains("\"erro\""))
            {
                MessageBox.Show("CEP não encontrado.", "Atenção",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Parse manual simples (evita dependência de JSON lib extra)
            TxtLogradouro.Text = ExtrairJson(json, "logradouro");
            TxtBairro.Text     = ExtrairJson(json, "bairro");
            TxtCidade.Text     = ExtrairJson(json, "localidade");

            // Selecionar UF no ComboBox
            var uf = ExtrairJson(json, "uf");
            foreach (ComboBoxItem item in CmbEstado.Items)
                if (item.Content?.ToString() == uf)
                { CmbEstado.SelectedItem = item; break; }

            TxtNumero.Focus();
        }
        catch
        {
            MessageBox.Show("Erro ao buscar CEP. Verifique sua conexão.",
                "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private string ExtrairJson(string json, string campo)
    {
        var match = Regex.Match(json, $"\"{campo}\"\\s*:\\s*\"([^\"]+)\"");
        return match.Success ? match.Groups[1].Value : string.Empty;
    }

    // ══════════════════════════════════════════
    // VALIDAÇÃO E SALVAR
    // ══════════════════════════════════════════
    private void BtnSalvar_Click(object sender, RoutedEventArgs e)
    {
        if (!Validar()) return;

        PacienteSalvo = new Paciente
        {
            Nome              = TxtNome.Text.Trim(),
            Cpf               = TxtCpf.Text.Trim(),
            Rg                = TxtRg.Text.Trim(),
            DataNascimento    = DtNascimento.SelectedDate ?? DateTime.MinValue,
            Genero            = (CmbGenero.SelectedItem as ComboBoxItem)?.Content?.ToString(),
            EstadoCivil       = (CmbEstadoCivil.SelectedItem as ComboBoxItem)?.Content?.ToString(),

            // IDs viriam de um ViewModel/binding real
            PessoaResponsavelId = 0,
            RecomendadoPorId    = 0,

            Cep               = TxtCep.Text.Trim(),
            Logradouro        = TxtLogradouro.Text.Trim(),
            Numero            = TxtNumero.Text.Trim(),
            Complemento       = TxtComplemento.Text.Trim(),
            Bairro            = TxtBairro.Text.Trim(),
            Cidade            = TxtCidade.Text.Trim(),
            Estado            = (CmbEstado.SelectedItem as ComboBoxItem)?.Content?.ToString(),
            Telefone          = TxtTelefone.Text.Trim(),
            Email             = TxtEmail.Text.Trim(),

            NomePai           = TxtNomePai.Text.Trim(),
            NomeMae           = TxtNomeMae.Text.Trim(),
            NomeConjuge       = TxtNomeConjuge.Text.Trim(),
            Profissao         = TxtProfissao.Text.Trim(),
            ConheceuPor       = CmbConheceuPor.SelectedIndex,
            Observacoes       = TxtObservacoes.Text.Trim(),
            Convenio          = TxtConvenio.Text.Trim(),
            NumeroConvenio    = TxtNumeroConvenio.Text.Trim(),
            PreferenciaHorario = (CmbPreferenciaHorario.SelectedItem as ComboBoxItem)?.Content?.ToString(),
            QueroReceberLembretes = ChkReceberLembretes.IsChecked ?? false,
        };

        DialogResult = true;
        Close();
    }

    private bool Validar()
    {
        if (string.IsNullOrWhiteSpace(TxtNome.Text))
        {
            MostrarErro("O campo Nome é obrigatório.", TxtNome);
            return false;
        }
        if (string.IsNullOrWhiteSpace(TxtCpf.Text) || TxtCpf.Text.Length < 14)
        {
            MostrarErro("CPF inválido ou não informado.", TxtCpf);
            return false;
        }
        if (DtNascimento.SelectedDate == null)
        {
            MostrarErro("Informe a data de nascimento.", null);
            return false;
        }
        if (string.IsNullOrWhiteSpace(TxtTelefone.Text) || TxtTelefone.Text.Length < 14)
        {
            MostrarErro("Telefone inválido ou não informado.", TxtTelefone);
            return false;
        }
        return true;
    }

    private void MostrarErro(string mensagem, TextBox campo)
    {
        MessageBox.Show(mensagem, "Campo obrigatório",
            MessageBoxButton.OK, MessageBoxImage.Warning);
        campo?.Focus();
    }

    // ══════════════════════════════════════════
    // FECHAR
    // ══════════════════════════════════════════
    private void BtnFechar_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
