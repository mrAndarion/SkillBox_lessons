using System;

namespace Task3_PrimeNumbers
{
    internal static class Program
    {
        private const string WarningInputMessage = "Please enter integer between {0} - {1}: ";
        private const string InputMessage = "Input the number to check is it prime number: ";
        private const string ResultMessage = "Number {0} is ";
        private const string PrimeNumber = "prime number ";
        private const string NotPrimeNumber = "not a prime number ";
        
        public static void Main(string[] args)
        {
            DisplayText(InputMessage);
            var number = GetValidInt(Console.ReadLine(), 0, int.MaxValue);
            var isPrime = CheckForPrime(number);

            DisplayText(isPrime
                ? string.Format(ResultMessage + PrimeNumber, number)
                : string.Format(ResultMessage + NotPrimeNumber, number));
        }

        private static bool CheckForPrime(int number)
        {
            var counter = 1;

            if (number == 0 || number == 1)
            {
                return false;
            }
            
            while (counter < number - 1)
            {
                counter++;
                if (number % counter == 0)
                {
                    return false;
                }
            }

            return true;
        }
        
        private static int GetValidInt(string inputString, int minValue, int maxValue)
        {
            int validInt;
            while (!int.TryParse(inputString, out validInt) || validInt < minValue || validInt > maxValue)
            {
                DisplayText(string.Format(WarningInputMessage, minValue, maxValue));
                inputString = Console.ReadLine();
            }
            return validInt;
        }
        
        private static void DisplayText(string text)
        {
            Console.WriteLine(text);
        }
    }
}