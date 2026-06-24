using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using ConsultorioUI.Models;
using ConsultorioUI.Services;
using ConsultorioUI.Views;

namespace ConsultorioUI.ViewModels;

public partial class ProntuarioViewModel : ObservableObject
{
    public ObservableCollection<Procedimento> Procedimentos { get; set; }
    public Paciente PacienteAtual { get; set; }
    [ObservableProperty] private string nome = "";
    [ObservableProperty] private string nomeValor;

    public ProntuarioViewModel(Paciente paciente)
    {
        PacienteAtual = paciente;
    }

    public async void Salvar(ProntuarioView prontuarioView)
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
                App.Navigation.Navigate("Prontuario",PacienteAtual);
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
}