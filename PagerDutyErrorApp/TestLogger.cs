using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Fh.Cof.Csl.Logging;


namespace PagerDutyErrorApp
{
    enum LogLevel
    {
        Error,
        Warning,
        Info,
        None
    }
    class TestLogger
    {
        private string errorLog = "Dit is een error log vanuit de test-app";
        private string warningLog = "Dit is een info log vanuit de test-app";
        private string infoLog = "Dit is een warning log vanuit de test-app";
        private LogLevel currentLogLevel = LogLevel.None;
        private Timer timer = new Timer(2000);

        public void changeInterval(int interval)
        {
            timer.Interval = interval;
        }

        public void setLogging(LogLevel level)
        {
            currentLogLevel = level;
            timer.Enabled = false;
            switch (level)
            {
                case LogLevel.Error:
                    timer.Elapsed += new ElapsedEventHandler(LogError);
                    timer.Enabled = true;
                    break;
                case LogLevel.Warning:
                    timer.Elapsed += new ElapsedEventHandler(LogWarning);
                    timer.Enabled = true;
                    break;
                case LogLevel.Info:
                    timer.Elapsed += new ElapsedEventHandler(LogInfo);
                    timer.Enabled = true;
                    break;
                case LogLevel.None:
                    stopLogging();
                    break;                   
            }           
        }

        private void stopLogging()
        {
            switch(currentLogLevel)
                {
                case LogLevel.Error:
                    timer.Elapsed -= LogError;
                    break;
                case LogLevel.Warning:
                    timer.Elapsed -= LogWarning;
                    break;
                case LogLevel.Info:
                    timer.Elapsed -= LogInfo;
                    break;
                }
            currentLogLevel = LogLevel.None;
            timer.Enabled = false;
        }

        private void LogError(object source, ElapsedEventArgs e)
        {
            currentLogLevel = LogLevel.Error;
            //timer.Enabled = true;
            if (currentLogLevel.Equals(LogLevel.Error))
            {
                Console.WriteLine("error");
                FhLogging.LogError(errorLog);
            }
        }

        private void LogWarning(object source, ElapsedEventArgs e)
        {
            currentLogLevel = LogLevel.Warning;
            //timer.Enabled = true;
            if (currentLogLevel.Equals(LogLevel.Warning))
            {
                Console.WriteLine("warning");
                FhLogging.LogError(warningLog);
            }
        }

        private void LogInfo(object source, ElapsedEventArgs e)
        {
            currentLogLevel = LogLevel.Info;
            //timer.Enabled = true;
            if (currentLogLevel.Equals(LogLevel.Info))
            {
                Console.WriteLine("info");
                FhLogging.LogError(infoLog);
            }
        }

    }
}
