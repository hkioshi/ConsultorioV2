using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using ConsultorioUI.Services;
using ConsultorioUI.ViewModels;
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

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            Window = new MainWindow();
            Navigation = new NavigationService(Window);
            desktop.MainWindow = Window;
        }

        base.OnFrameworkInitializationCompleted();
    }
}