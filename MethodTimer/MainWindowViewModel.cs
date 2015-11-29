using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Commander;
using PropertyChanged;

namespace MethodTimer
{
    [ImplementPropertyChanged]
    public class MainWindowViewModel
    {
        public string Output { get; set; }
        public string Timings { get; set; }

        [OnCommand("RunCommand")]
        void OnRun()
        {
            var worker = new BackgroundWorker();

            worker.WorkerReportsProgress = true;
            worker.DoWork += (sender, e) =>
            {
                for (int i = 9000000; i < 9005000; i++)
                {
                    if (IsPrime(i))
                        worker.ReportProgress(i);
                }
            };
            worker.ProgressChanged += (sender, e) =>
            {
                Output += $"{e.ProgressPercentage} is prime." + Environment.NewLine;
            };

            worker.RunWorkerAsync();
        }

        [Time]
        static bool IsPrime(int i)
        {
            if (i == 0 || i == 1)
            {
                return false;
            }

            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                    return false;
            }

            return true;
        }
    }

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