using System.ComponentModel;

namespace PropertyChanged
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class MainWindowViewModel : BaseViewModel
    {
        public string Greeting { get; set; }
    }
}