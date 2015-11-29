using Anotar.Custom;
using PropertyChanged;

namespace Anotar
{
    [ImplementPropertyChanged]
    class MainWindowViewModel
    {
        public string Greeting { get; set; }

        private void OnGreetingChanged()
        {
            LogTo.Information("Greeting changed: {0}", Greeting);
        }

        [DependsOn(nameof(Greeting))]
        public string Output => LoggerFactory.LogOutput;
    }
}