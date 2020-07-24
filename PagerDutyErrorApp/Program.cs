using System;
using System.Timers;

/*
* logregel
* verschillende serverities in error melding (case "high " >> xxxx)
* throw exception 
* 
*/
namespace PagerDutyErrorApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestLogger testLogger = new TestLogger();


            // Display title as the C# console calculator app.
            Console.WriteLine("Console PagerDutyError\r");
            Console.WriteLine("------------------------\n");
            // Ask the user to choose an option.
            Console.WriteLine("Choose an option:");
            Console.WriteLine("\t1 - log info");
            Console.WriteLine("\t2 - log warning");
            Console.WriteLine("\t3 - log error");
            Console.WriteLine("\t4 - stop logging");
            Console.WriteLine("\tq - to quit");
            TickTock(testLogger);
        }

        private static void TickTock(TestLogger testLogger)
        {
            bool on = true;
            while (on)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("logging at info level now");
                        testLogger.setLogging(LogLevel.Info);
                        break;
                    case "2":
                        Console.WriteLine("logging at warning level now");
                        testLogger.setLogging(LogLevel.Warning);
                        break;
                    case "3":
                        Console.WriteLine("logging at error level now");
                        testLogger.setLogging(LogLevel.Error);
                        break;
                    case "4":
                        Console.WriteLine("no logging");
                        testLogger.setLogging(LogLevel.None);
                        break;
                    case "q":
                        on = false;
                        break;
                    default:
                        Console.WriteLine("input not valid");
                        break;
                }
            }
        }



    }
}
