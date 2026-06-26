using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using ConsultorioUI.Models;
using ConsultorioUI.Services;
using ConsultorioUI.Views;

namespace ConsultorioUI.ViewModels;

public partial class ProntuarioViewModel : ObservableObject
{
    public ObservableCollection<Procedimento> Procedimentos { get; set; }
    public ObservableCollection<Tratamento> Tratamentos { get; set; }
    public Paciente PacienteAtual { get; set; }
    public ProntuarioViewModel(Paciente paciente)
    {
        PacienteAtual = paciente;
        Tratamentos = [new Tratamento
        {
            Id = 1,
            Dente = 16,
            Status = "Teste",
            Valor = 100
        }];
    }
    public async Task Salvar(ProntuarioView prontuarioView)
    {
        List<string> DentesMarcados= [];
        foreach (var item in prontuarioView.GrdSuperior.Children.OfType<CheckBox>())
        {
            if(item.IsChecked == true)
                DentesMarcados.Add(item.Tag.ToString());
        }
        foreach (var item in prontuarioView.GrdInferior.Children.OfType<CheckBox>())
        {
            if(item.IsChecked == true)
                DentesMarcados.Add(item.Tag.ToString());
        }

        foreach (string item in DentesMarcados)
        {
            try
            {
                CreateTratamentoDto novoTratamento = new CreateTratamentoDto
                {
                    Data =  DateTime.Now,
                    Dente = int.Parse(item),
                    Distal = prontuarioView.FaceDistal.IsChecked == true ? true : false,
                    LingualPalatina = prontuarioView.FaceLingual.IsChecked == true ? true : false,
                    Mesial =  prontuarioView.FaceMesial.IsChecked == true ? true : false,
                    Observacoes = prontuarioView.Anotacoes.Text ?? "",
                    Vestibular = prontuarioView.FaceVestibular.IsChecked == true ? true : false,
                    OclusalIncisal = prontuarioView.FaceOclusal.IsChecked == true ? true : false,
                    Procedimento =  prontuarioView.TratamentoNome.Text ?? "",
                    ProntuarioId =  await DatabaseService.BuscarIdProntuarioPorIdPaciente(PacienteAtual.Id.ToString()),
                    Status = "Nao Pago",
                    Valor = VerNumerodeFaces(prontuarioView) * ValidacaoService.ValidarDouble(prontuarioView.TratamentoValor.Text)
                };
                await DatabaseService.SalvarNovoTratamento(novoTratamento);
                App.Navigation.Atualizar("Prontuario",PacienteAtual);
                Console.WriteLine("Tratamento Salvo com sucesso!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
    private int VerNumerodeFaces(ProntuarioView prontuarioView)
    {
        int faces = 0;
        if (prontuarioView.Completo.IsChecked == true) return 1;
        
        faces += prontuarioView.FaceOclusal.IsChecked == true ? 1 : 0;
        faces += prontuarioView.FaceLingual.IsChecked == true ? 1 : 0;
        faces += prontuarioView.FaceVestibular.IsChecked == true ? 1 : 0;
        faces += prontuarioView.FaceMesial.IsChecked == true ? 1 : 0;
        faces += prontuarioView.FaceDistal.IsChecked == true ? 1 : 0;
        
        return faces;
    }
    public async Task IniciarTabela(ProntuarioView prontuarioView)
    {
        int idTratamento = await DatabaseService.BuscarIdProntuarioPorIdPaciente(
            PacienteAtual.Id.ToString());

        if (ValidacaoService.ValidarNull(idTratamento))
        {
            var lista = await DatabaseService.ExibirTratamentos(idTratamento);

            Tratamentos.Clear();

            foreach (var item in lista ?? [])
            {
                Tratamentos.Add(item);
            }
            prontuarioView.TotalTratamentos.Text = Tratamentos.Count + " Tratamento";
        }
        
    }
    public async void AbrirDescricao(string? id, Visual visual)
    {
        var tratamento = await DatabaseService.BuscarTratamento(id);
        if (tratamento != null)
        {
            bool alterou = false;
            var dialog = new EditarTratamentoDialog(tratamento);

            var window = TopLevel.GetTopLevel(visual) as Window;
            if (window != null)
                alterou = await dialog.ShowDialog<bool>(window);

            if (alterou)
            {
                App.Navigation.Atualizar("Prontuario", PacienteAtual);
            }

        }
             

    }
}