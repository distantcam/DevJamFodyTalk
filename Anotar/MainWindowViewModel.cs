using Anotar.Custom;

namespace Anotar
{
    class MainWindowViewModel : BaseViewModel
    {
        public string Greeting { get; set; }

        private void OnGreetingChanged()
        {
            LogTo.Information("Greeting changed: {0}", Greeting);
            OnPropertyChanged(nameof(Output));
        }

        public string Output => LoggerFactory.LogOutput;
    }
}