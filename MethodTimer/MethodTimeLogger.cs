using System;
using System.Windows;
using System.Reflection;
using System.Windows.Threading;

namespace MethodTimer
{

    public static class MethodTimeLogger
    {
        public static void Log(MethodBase methodBase, long milliseconds)
        {
            if (milliseconds > 0)
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ViewModel.Timings += $"{methodBase.Name} took {milliseconds}ms" + Environment.NewLine;
                }), DispatcherPriority.Background);
        }

        public static MainWindowViewModel ViewModel { get; set; }
    }
}