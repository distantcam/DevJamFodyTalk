using System;

namespace Anotar
{
    public static class LoggerFactory
    {
        public static Logger GetLogger<T>() => new Logger();

        public static string LogOutput { get; set; }
    }

    public class Logger
    {
        public bool IsInformationEnabled => true;

        public void Information(string format, params object[] args)
        {
            LoggerFactory.LogOutput += string.Format(format, args) + Environment.NewLine;
        }
    }
}