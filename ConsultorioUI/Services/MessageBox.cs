using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using ConsultorioUI.Views;

namespace ConsultorioUI.Services;

public static class MessageBox
{
    public static  void Show(string message)
    {
        var parentWindow = App.Window;

        var okButton = new Button
        {
            Content = "OK",
            HorizontalAlignment = HorizontalAlignment.Center,
            Padding = new Thickness(24, 8),
            Margin = new Thickness(0, 12, 0, 0)
        };

        var dialog = new Window
        {
            Title = "Aviso",
            Width = 320,
            SizeToContent = SizeToContent.Height,
            CanResize = false,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new StackPanel
            {
                Margin = new Thickness(24),
                HorizontalAlignment = HorizontalAlignment.Center,
                Children =
                {
                    new TextBlock
                    {
                        Text = message,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    },
                    okButton
                }
            }
        };

        okButton.Click += (_, _) => dialog.Close();

        dialog.ShowDialog(parentWindow);
    }
    
    public static async Task<bool> ShowWarning(string message)
    {
        var parentWindow = App.Window;

        var naoButton = new Button
        {
            Margin = Thickness.Parse("3"),

            Content = "Não"
        };

        var simButton = new Button
        {
            Margin = Thickness.Parse("3"),

            Content = "Sim"
        };

        var dialog = new Window
        {
            Title = "Aviso",
            Width = 320,
            SizeToContent = SizeToContent.Height,
            CanResize = false,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new StackPanel
            {
                Margin = new Thickness(24),
                Children =
                {
                    new TextBlock
                    {
                        Text = message,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center
                    },
                    new StackPanel
                    {
                        Orientation =  Orientation.Horizontal,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Children =
                        {
                            naoButton,
                            simButton
                        }
                    },
                }
            }
        };

        naoButton.Click += (_, _) => dialog.Close(false);
        simButton.Click += (_, _) => dialog.Close(true);

        return await dialog.ShowDialog<bool>(parentWindow);
    }
    
    
}