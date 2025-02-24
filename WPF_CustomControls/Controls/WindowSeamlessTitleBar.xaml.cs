using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;

namespace WPF_CustomControls.Controls;

public partial class WindowSeamlessTitleBar : UserControl
{
    public WindowSeamlessTitleBar()
    {
        InitializeComponent();
        Loaded += CutomWindowTitleBar_Loaded;
    }

    private void CutomWindowTitleBar_Loaded(object sender, RoutedEventArgs e)
    {
        var window = Window.GetWindow(this);

        if (EnableParentCheck)
        {
            DependencyObject current = VisualTreeHelper.GetParent(this);
            while (current != null)
            {
                if (current is Page)
                {
                    throw new InvalidOperationException($"{typeof(WindowSeamlessTitleBar).FullName} должен использоваться только в окнах, а не на страницах {typeof(Page).FullName}");
                }
                if (current is UserControl)
                {
                    throw new InvalidOperationException($"{typeof(WindowSeamlessTitleBar).FullName} должен использоваться только в окнах, а не в контролах {typeof(UserControl).FullName}");
                }
                current = VisualTreeHelper.GetParent(current);
            }
        }

        if (window == null)
        {
            throw new InvalidOperationException("WindowSeamlessTitleBar должен быть размещён внутри окна.");
        }

        WindowChrome.SetWindowChrome(
            window,
            new WindowChrome
            {
                CaptionHeight = 50,
                CornerRadius = default,
                GlassFrameThickness = new Thickness(-1),
                ResizeBorderThickness = window.ResizeMode == ResizeMode.NoResize ? default : new Thickness(4),
                UseAeroCaptionButtons = true
            }
        );

        Loaded -= CutomWindowTitleBar_Loaded;
    }

    public static readonly DependencyProperty EnableParentCheckProperty =
    DependencyProperty.Register(
        nameof(EnableParentCheck),
        typeof(bool),
        typeof(WindowSeamlessTitleBar),
        new PropertyMetadata(true));

    public bool EnableParentCheck
    {
        get => (bool)GetValue(EnableParentCheckProperty);
        set => SetValue(EnableParentCheckProperty, value);
    }

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(WindowSeamlessTitleBar), new PropertyMetadata(string.Empty));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty BackCommandProperty =
        DependencyProperty.Register(nameof(BackCommand), typeof(ICommand), typeof(WindowSeamlessTitleBar), new PropertyMetadata(null));

    public ICommand BackCommand
    {
        get => (ICommand)GetValue(BackCommandProperty);
        set => SetValue(BackCommandProperty, value);
    }

    public static readonly DependencyProperty ForwardCommandProperty =
        DependencyProperty.Register(nameof(ForwardCommand), typeof(ICommand), typeof(WindowSeamlessTitleBar), new PropertyMetadata(null));

    public ICommand ForwardCommand
    {
        get => (ICommand)GetValue(ForwardCommandProperty);
        set => SetValue(ForwardCommandProperty, value);
    }

    public static readonly DependencyProperty ShowBackButtonProperty =
        DependencyProperty.Register(nameof(ShowBackButton), typeof(bool), typeof(WindowSeamlessTitleBar), new PropertyMetadata(true));

    public bool ShowBackButton
    {
        get => (bool)GetValue(ShowBackButtonProperty);
        set => SetValue(ShowBackButtonProperty, value);
    }

    public static readonly DependencyProperty ShowForwardButtonProperty =
        DependencyProperty.Register(nameof(ShowForwardButton), typeof(bool), typeof(WindowSeamlessTitleBar), new PropertyMetadata(false));

    public bool ShowForwardButton
    {
        get => (bool)GetValue(ShowForwardButtonProperty);
        set => SetValue(ShowForwardButtonProperty, value);
    }

    public static readonly DependencyProperty IconSourceProperty =
        DependencyProperty.Register(nameof(IconSource), typeof(ImageSource), typeof(WindowSeamlessTitleBar), new PropertyMetadata(null));

    public ImageSource IconSource
    {
        get => (ImageSource)GetValue(IconSourceProperty);
        set => SetValue(IconSourceProperty, value);
    }

    public static readonly DependencyProperty ShowIconProperty =
        DependencyProperty.Register(nameof(ShowIcon), typeof(bool), typeof(WindowSeamlessTitleBar), new PropertyMetadata(true));

    public bool ShowIcon
    {
        get => (bool)GetValue(ShowIconProperty);
        set => SetValue(ShowIconProperty, value);
    }

    private void MinimizeWindow(object sender, RoutedEventArgs e)
    {
        var window = Window.GetWindow(this);
        if (window != null)
        {
            window.WindowState = WindowState.Minimized;
        }
    }

    private void MaximizeWindow(object sender, RoutedEventArgs e)
    {
        var window = Window.GetWindow(this);
        if (window != null)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
                MaximizeIcon.Text = "\uE922";
            }
            else
            {
                window.WindowState = WindowState.Maximized;
                MaximizeIcon.Text = "\uE923";
            }
        }
    }

    private void CloseWindow(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}
