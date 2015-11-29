using System.ComponentModel;
using System.Windows;

namespace MethodTimer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = new MainWindowViewModel();
            this.DataContext = vm;
            MethodTimeLogger.ViewModel = vm;
            ((INotifyPropertyChanged)vm).PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Output")
                    output.ScrollToBottom();
                if (e.PropertyName == "Timings")
                    timings.ScrollToBottom();
            };
        }
    }
}