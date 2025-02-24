using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF_CustomControls;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public ICommand NavigateBackCommand { get; }
    public ICommand NavigateForwardCommand { get; }

    private string _windowTitle = "Мои контролы";
    public string WindowTitle
    {
        get => _windowTitle;
        set
        {
            _windowTitle = value;
            OnPropertyChanged(nameof(WindowTitle));
        }
    }

    // Пример: путь к иконке окна
    private ImageSource _windowIcon;
    public ImageSource WindowIcon
    {
        get => _windowIcon;
        set
        {
            _windowIcon = value;
            OnPropertyChanged(nameof(WindowIcon));
        }
    }

    // Свойства для управления видимостью кнопок и иконки
    public bool ShowBack { get; set; } = true;
    public bool ShowForward { get; set; } = false;
    public bool ShowIcon { get; set; } = true;

    public MainWindowViewModel()
    {
        NavigateBackCommand = new RelayCommand(ExecuteNavigateBack);
        NavigateForwardCommand = new RelayCommand(ExecuteNavigateForward);
    }

    private void ExecuteNavigateBack(object parameter)
    {
        // Здесь размещаем логику для перехода назад
        MessageBox.Show("Нажата кнопка 'Назад'");
    }

    private void ExecuteNavigateForward(object parameter)
    {
        // Здесь размещаем логику для перехода вперёд
        MessageBox.Show("Нажата кнопка 'Вперёд'");
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
