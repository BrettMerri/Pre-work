using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeBetweenTwoDates
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true) { //infinite loop
                Console.Clear();
                Console.WriteLine("This application calculates the time between two dates in Years, Months, and Days.");
                Console.WriteLine("Input dates in the format: MM/DD/YYYY.");

                Console.WriteLine("\nInput first date below:"); //Prompt for first date
                string firstDateInput = Console.ReadLine();
                if (isValidDate(firstDateInput) == false)
                {
                    continue;
                }

                Console.WriteLine("\nInput second date below:"); //Prompt for second date
                string secondDateInput = Console.ReadLine();
                if (isValidDate(secondDateInput) == false)
                {
                    continue;
                }

                DateTime firstDate = DateTime.ParseExact(firstDateInput, "d", null);
                DateTime secondDate = DateTime.ParseExact(secondDateInput, "d", null);

                TimeSpan duration;

                if (firstDate >= secondDate) //Always subtract latest date to earliest date
                {
                    duration = firstDate - secondDate;
                }
                else
                {
                    duration = secondDate - firstDate;
                }

                double totalDaysBetween = duration.Days;

                double yearsBetween = calculateYearsBetween(totalDaysBetween);
                double monthsBetween = calculateMonthsBetween(totalDaysBetween, yearsBetween);
                double daysBetween = calculateDaysBetween(totalDaysBetween, yearsBetween, monthsBetween);

                string output = String.Format("Years: {0}\nMonths: {1}\nDays: {2}", yearsBetween, monthsBetween, daysBetween);

                Console.Clear();
                Console.WriteLine(output);
                Console.ReadKey();
            }
        }
        public static bool isValidDate(string date)
        {
            DateTime temp;
            if (!DateTime.TryParseExact(date, "d",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out temp)) //if user input is in small date format return true
            {
                Console.Clear();
                Console.WriteLine("Error: Invalid date!\n\nPress any key to continue...");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        public static double calculateYearsBetween(double totalDaysBetween)
        {
            double yearsBetween = Math.Floor(totalDaysBetween / 365);
            return yearsBetween;
        }
        public static double calculateMonthsBetween(double totalDaysBetween, double yearsBetween)
        {
            double monthsBetween = Math.Floor((totalDaysBetween - (yearsBetween * 365)) / 30);
            return monthsBetween;
        }
        public static double calculateDaysBetween(double totalDaysBetween, double yearsBetween, double monthsBetween)
        {
            double daysBetween = totalDaysBetween - ((yearsBetween * 365) + (monthsBetween * 30));
            return daysBetween;
        }
    }
}
