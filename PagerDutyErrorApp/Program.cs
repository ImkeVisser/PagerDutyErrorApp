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
            // Display title as the C# console calculator app.
            Console.WriteLine("Console PagerDutyError\r");
            Console.WriteLine("------------------------\n");



            // Ask the user to choose an option.
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - logregel - niet interessant");
            Console.WriteLine("\t2 - Low");
            Console.WriteLine("\t3 - Medium");
            Console.WriteLine("\t4 - High");
            Console.WriteLine("\t5 - Urgent");
            Console.Write("Your option? ");



            // Use a switch statement to do the math.
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine($"Niet interessant");
                    break;
                case "2":
                    TickTock(5000);
                    break;
                case "3":
                    TickTock(2000);
                    break;
                case "4":
                    TickTock(500);
                    break;
                case "5":
                    TickTock(5);
                    break;
            }
            // Wait for the user to respond before closing.
            Console.Write("Press any key to close PagerDutyError...");
            Console.ReadKey();
        }



        public static void TickTock(int interval)
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = interval;
            aTimer.Enabled = true;
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }
        // Specify what you want to happen when the Elapsed event is raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Groen van buiten, Rood van binnen.... Watermeloen");
        }
    }
}
