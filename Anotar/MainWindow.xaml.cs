using System.ComponentModel;
using System.Windows;

namespace Anotar
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = new MainWindowViewModel();
            this.DataContext = vm;
            ((INotifyPropertyChanged)vm).PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Output")
                    output.ScrollToBottom();
            };
        }
    }
}