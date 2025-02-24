using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_CustomControls.Controls;

public partial class HyperLinkText : UserControl
{
    public HyperLinkText()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty NavigateURIProperty =
    DependencyProperty.Register(
    nameof(NavigateURI),
    typeof(string),
    typeof(WindowSeamlessTitleBar),
    new PropertyMetadata(string.Empty));

    public string? NavigateURI
    {
        get => GetValue(NavigateURIProperty) as string;
        set => SetValue(NavigateURIProperty, value);
    }

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(WindowSeamlessTitleBar),
        new PropertyMetadata(string.Empty));

    public string? Text
    {
        get => GetValue(TextProperty) as string;
        set => SetValue(TextProperty, value);
    }

    private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(NavigateURI))
            {
                var psi = new ProcessStartInfo
                {
                    FileName = NavigateURI,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Не удалось перейти по ссылке '{NavigateURI}': {ex.Message}");
        }
    }
}