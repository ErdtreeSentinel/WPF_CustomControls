using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_CustomControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            (this.DataContext as MainWindowViewModel).WindowIcon = new BitmapImage(new Uri("pack://application:,,,/Assets/WPFCustomControls.png"));
            (this.DataContext as MainWindowViewModel).ShowForward = false;
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
    }
}