using System;
using System.ComponentModel;
using PropertyChanged;

namespace Commander
{
    [ImplementPropertyChanged]
    class MainWindowViewModel
    {
        public string Output { get; set; }

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
}