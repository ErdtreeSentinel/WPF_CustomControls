using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;

namespace WPF_CustomControls.Controls;

/// <summary>
/// Interaction logic for SettingsExpander.xaml
/// </summary>
[ContentProperty("Items")]
public partial class SettingsExpander : UserControl
{
    public ObservableCollection<UIElement> Items { get; } = new ObservableCollection<UIElement>();
    public SettingsExpander()
    {
        InitializeComponent();
    }

    // Добавьте этот код после уже существующих свойств
    public static readonly DependencyProperty HeaderFontSizeProperty =
        DependencyProperty.Register("HeaderFontSize", typeof(double), typeof(SettingsExpander), new PropertyMetadata(14.0));

    public double HeaderFontSize
    {
        get => (double)GetValue(HeaderFontSizeProperty);
        set => SetValue(HeaderFontSizeProperty, value);
    }

    // Свойство для иконки (например, строка с символом из специального шрифта)
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(string), typeof(SettingsExpander), new PropertyMetadata(string.Empty));

    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly DependencyProperty ShowIconProperty =
    DependencyProperty.Register(nameof(ShowIcon), typeof(bool), typeof(SettingsExpander), new PropertyMetadata(true));

    public bool ShowIcon
    {
        get => (bool)GetValue(ShowIconProperty);
        set => SetValue(ShowIconProperty, value);
    }

    // Header как объект (можно задать как строку или вложенный элемент)
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register("Header", typeof(object), typeof(SettingsExpander), new PropertyMetadata(null));
    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    // Description как объект
    public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register("Description", typeof(object), typeof(SettingsExpander), new PropertyMetadata(null));
    public object Description
    {
        get => GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    // Правый контент — может быть любым контролом
    public static new readonly DependencyProperty ContentProperty =
        DependencyProperty.Register("Content", typeof(object), typeof(SettingsExpander), new PropertyMetadata(null));

    public new object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }
}
