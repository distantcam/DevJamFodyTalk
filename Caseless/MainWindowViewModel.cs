using PropertyChanged;

namespace Caseless
{
    [ImplementPropertyChanged]
    class MainWindowViewModel
    {
        public string Greeting { get; set; }

        public bool IsCorrectGreeting => Greeting == "Perth Dot Net";
    }
}