using System;

namespace Task1EvenOdd
{
    internal static class Program
    {
        private const string InputMessage = "Input number to check even/odd: ";
        private const string WarningInputMessage = "Please enter integer between {0} - {1}: ";
        private const string EvenResultMessage = "Number {0} is - even ";
        private const string OddResultMessage = "Number {0} is - odd ";
        
        public static void Main(string[] args)
        {
            DisplayText(InputMessage);
            var numberForCheck = GetValidInt(Console.ReadLine(), int.MinValue, int.MaxValue);
            DisplayText(CheckEven(numberForCheck)
                ? string.Format(EvenResultMessage, numberForCheck)
                : string.Format(OddResultMessage, numberForCheck));
        }
        
        private static bool CheckEven(int numberForCheck)
        {
            return numberForCheck % 2 == 0;
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