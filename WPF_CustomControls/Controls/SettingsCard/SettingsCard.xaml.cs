using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_CustomControls.Controls;

/// <summary>
/// Interaction logic for SettingsCard.xaml
/// </summary>
public partial class SettingsCard : UserControl
{
    public SettingsCard()
    {
        InitializeComponent();
    }

    // Добавьте этот код после уже существующих свойств
    public static readonly DependencyProperty HeaderFontSizeProperty =
        DependencyProperty.Register("HeaderFontSize", typeof(double), typeof(SettingsCard), new PropertyMetadata(14.0));

    public double HeaderFontSize
    {
        get => (double)GetValue(HeaderFontSizeProperty);
        set => SetValue(HeaderFontSizeProperty, value);
    }

    // Свойство для иконки (например, строка с символом из специального шрифта)
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(string), typeof(SettingsCard), new PropertyMetadata(string.Empty));

    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly DependencyProperty ShowIconProperty =
    DependencyProperty.Register(nameof(ShowIcon), typeof(bool), typeof(SettingsCard), new PropertyMetadata(true));

    public bool ShowIcon
    {
        get => (bool)GetValue(ShowIconProperty);
        set => SetValue(ShowIconProperty, value);
    }

    // Header как объект (можно задать как строку или вложенный элемент)
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register("Header", typeof(object), typeof(SettingsCard), new PropertyMetadata(null));
    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    // Description как объект
    public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register("Description", typeof(object), typeof(SettingsCard), new PropertyMetadata(null));
    public object Description
    {
        get => GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    // Правый контент — может быть любым контролом
    public static new readonly DependencyProperty ContentProperty =
        DependencyProperty.Register("Content", typeof(object), typeof(SettingsCard), new PropertyMetadata(null));

    public new object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    #region клик по карточке

    // Новое свойство IsClickEnabled
    public static readonly DependencyProperty IsClickEnabledProperty =
        DependencyProperty.Register("IsClickEnabled", typeof(bool), typeof(SettingsCard), new PropertyMetadata(false));

    public bool IsClickEnabled
    {
        get => (bool)GetValue(IsClickEnabledProperty);
        set => SetValue(IsClickEnabledProperty, value);
    }

    // Новое событие Click
    public event RoutedEventHandler Click;

    // Обработчик клика по карточке
    private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (IsClickEnabled && Click != null)
        {
            Click(this, new RoutedEventArgs());
        }
    }
    #endregion
}
