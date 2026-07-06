using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System.Net.Http;
using Avalonia.Markup.Xaml;
using ConsultorioUI.Services;
using ConsultorioUI.Views;

namespace ConsultorioUI;

public partial class App : Application
{

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    public static NavigationService Navigation { get; private set; } = null!;
    public static MainWindow Window {get; private set; } = null!;
    public static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://localhost:7256/")
    };
    
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            Console.WriteLine($"Main - PID {Environment.ProcessId}");
            Window = new MainWindow();
            Navigation = new NavigationService();
            desktop.MainWindow = Window;
        }
        base.OnFrameworkInitializationCompleted();
    
    }
}