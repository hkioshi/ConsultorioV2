using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

using Avalonia.Controls;
using Avalonia.Interactivity;

using ConsultorioUI.Models;
using ConsultorioUI.Services;

namespace ConsultorioUI.Views;

public partial class NovoPacienteDialog : Window
{
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

        TabPessoal.IsVisible = false;
        TabContato.IsVisible = false;
        TabExtra.IsVisible   = false;

        switch (tag)
        {
            case "TabPessoal": TabPessoal.IsVisible = true; break;
            case "TabContato": TabContato.IsVisible = true; break;
            case "TabExtra":   TabExtra.IsVisible   = true; break;
        }
    }

    // ══════════════════════════════════════════
    // MÁSCARAS
    // ══════════════════════════════════════════
    private void TxtCpf_TextChanging(object sender, TextChangingEventArgs e)
    {
        var tb = sender as TextBox;
        if (tb == null) return;

        var digits = Regex.Replace(tb.Text ?? "", @"\D", "");
        if (digits.Length > 11) digits = digits[..11];

        string masked = digits;
        if (digits.Length >= 4)  masked = digits[..3] + "." + digits[3..];
        if (digits.Length >= 7)  masked = masked[..7] + "." + digits[6..];
        if (digits.Length >= 10) masked = masked[..11] + "-" + digits[9..];

        if (tb.Text != masked)
        {
            tb.TextChanging -= TxtCpf_TextChanging;
            tb.Text = masked;
            tb.CaretIndex = masked.Length;
            tb.TextChanging += TxtCpf_TextChanging;
        }
    }

    private void TxtTelefone_TextChanging(object sender, TextChangingEventArgs e)
    {
        var tb = sender as TextBox;
        if (tb == null) return;

        var digits = Regex.Replace(tb.Text ?? "", @"\D", "");
        if (digits.Length > 11) digits = digits[..11];

        string masked = digits;
        if (digits.Length >= 1) masked = "(" + digits;
        if (digits.Length >= 3) masked = "(" + digits[..2] + ") " + digits[2..];
        if (digits.Length >= 8)
        {
            int splitAt = digits.Length == 11 ? 7 : 6;
            masked = "(" + digits[..2] + ") "
                   + digits[2..(2 + splitAt)] + "-"
                   + digits[(2 + splitAt)..];
        }

        if (tb.Text != masked)
        {
            tb.TextChanging -= TxtTelefone_TextChanging;
            tb.Text = masked;
            tb.CaretIndex = masked.Length;
            tb.TextChanging += TxtTelefone_TextChanging;
        }
    }

    private void TxtCep_TextChanging(object sender, TextChangingEventArgs e)
    {
        var tb = sender as TextBox;
        if (tb == null) return;

        var digits = Regex.Replace(tb.Text ?? "", @"\D", "");
        if (digits.Length > 8) digits = digits[..8];

        string masked = digits.Length >= 6
            ? digits[..5] + "-" + digits[5..]
            : digits;

        if (tb.Text != masked)
        {
            tb.TextChanging -= TxtCep_TextChanging  ;
            tb.Text = masked;
            tb.CaretIndex = masked.Length;
            tb.TextChanging += TxtCep_TextChanging;
        }
    }

    // ══════════════════════════════════════════
    // BUSCA DE CEP (ViaCEP)
    // ══════════════════════════════════════════
    private async void BtnBuscarCep_Click(object sender, RoutedEventArgs e)
    {
        var cep = Regex.Replace(TxtCep.Text ?? "", @"\D", "");
        if (cep.Length != 8)
        {
            MessageBox.Show(this,"CEP inválido. Digite os 8 dígitos.");
            return;
        }

        try
        {
            using var http = new HttpClient();
            var json = await http.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (json.Contains("\"erro\""))
            {
                MessageBox.Show(this,"CEP não encontrado.");
                return;
            }

            TxtLogradouro.Text = ExtrairJson(json, "logradouro");
            TxtBairro.Text     = ExtrairJson(json, "bairro");
            TxtCidade.Text     = ExtrairJson(json, "localidade");

            var uf = ExtrairJson(json, "uf");
            foreach (ComboBoxItem item in CmbEstado.Items)
                if (item.Content?.ToString() == uf)
                { CmbEstado.SelectedItem = item; break; }

            TxtNumero.Focus();
        }
        catch
        {
            MessageBox.Show(this,"Erro ao buscar CEP. Verifique sua conexão.");
        }
    }

    private static string ExtrairJson(string json, string campo)
    {
        var match = Regex.Match(json, $"\"{campo}\"\\s*:\\s*\"([^\"]+)\"");
        return match.Success ? match.Groups[1].Value : string.Empty;
    }

    // ══════════════════════════════════════════
    // VALIDAÇÃO E SALVAR
    // ══════════════════════════════════════════
    private async void BtnSalvar_Click(object sender, RoutedEventArgs e)
    {
        if (!Validar()) return;

        // Avalonia não tem Console.Beep() nativo — remova ou substitua por som do sistema
        // Console.Beep();

        PacienteSalvo = new Paciente
        {
            Nome           = TxtNome.Text?.Trim() ?? "",
            Cpf            = TxtCpf.Text?.Trim() ?? "",
            Rg             = TxtRg.Text?.Trim() ?? "",
            DataNascimento = DtNascimento.SelectedDate?.Date ?? DateTime.MinValue,  // DatePicker retorna DateTimeOffset?
            Genero         = (CmbGenero.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "",
            EstadoCivil    = (CmbEstadoCivil.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "",

            PessoaResponsavelId = 0,
            RecomendadoPorId    = 0,

            Cep          = TxtCep.Text?.Trim() ?? "",
            Logradouro   = TxtLogradouro.Text?.Trim() ?? "",
            Numero       = TxtNumero.Text?.Trim() ?? "",
            Complemento  = TxtComplemento.Text?.Trim() ?? "",
            Bairro       = TxtBairro.Text?.Trim() ?? "",
            Cidade       = TxtCidade.Text?.Trim() ?? "",
            Estado       = (CmbEstado.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "",
            Telefone     = TxtTelefone.Text?.Trim() ?? "",
            Email        = TxtEmail.Text?.Trim() ?? "",

            NomePai            = TxtNomePai.Text?.Trim() ?? "",
            NomeMae            = TxtNomeMae.Text?.Trim() ?? "",
            NomeConjuge        = TxtNomeConjuge.Text?.Trim() ?? "",
            Profissao          = TxtProfissao.Text?.Trim() ?? "",
            ConheceuPor        = CmbConheceuPor.SelectedIndex,
            Observacoes        = TxtObservacoes.Text?.Trim() ?? "",
            Convenio           = TxtConvenio.Text?.Trim() ?? "",
            NumeroConvenio     = TxtNumeroConvenio.Text?.Trim() ?? "",
            PreferenciaHorario = (CmbPreferenciaHorario.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "",
            QueroReceberLembretes = ChkReceberLembretes.IsChecked ?? false,
        };

        const string urlPaciente   = "https://localhost:7256/Paciente";
        const string urlProntuario = "https://localhost:7256/Prontuario";

        using HttpClient client = new();

        var response = await client.PostAsync(
            urlPaciente,
            new StringContent(JsonSerializer.Serialize(PacienteSalvo), Encoding.UTF8, "application/json"));

        var pacienteCriado = await response.Content.ReadFromJsonAsync<Paciente>();

        await client.PostAsync(
            urlProntuario,
            new StringContent(
                JsonSerializer.Serialize(new ProntuarioId { PacienteId = pacienteCriado!.Id }),
                Encoding.UTF8, "application/json"));

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

    private void MostrarErro(string mensagem, TextBox? campo)
    {
        MessageBox.Show(this,mensagem);
        campo?.Focus();
    }

    // ══════════════════════════════════════════
    // FECHAR
    // ══════════════════════════════════════════
    private void BtnFechar_Click(object sender, RoutedEventArgs e)
    {
        // Avalonia não tem DialogResult; use Close() com valor se necessário
        Close();
    }

    private void CmbRecomendadoPor_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // implementar conforme necessidade
    }
}