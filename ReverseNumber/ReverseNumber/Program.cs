using System;
using System.Linq;

namespace ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) //Loops application
            {
                Console.Clear();
                Console.WriteLine("Input number below:");
                var input = Console.ReadLine();

                if (input == "") //Check if no input
                {
                    Console.Clear();
                    Console.WriteLine("Error: no input\n\nPress any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                bool isNumeric = input.All(char.IsDigit); // Check if input is numeric
                if (isNumeric == false)
                {
                    Console.Clear();
                    Console.WriteLine("Error: input not a number\n\nPress any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                string output = reverseString(input);

                Console.WriteLine("Reversed number: " + output + "\n\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        public static string reverseString(string x)
        {
            char[] charArray = x.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
