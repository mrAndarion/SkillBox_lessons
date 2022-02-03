using System;

namespace Task2_minValue
{
    internal static class Program
    {
        private const string WarningInputMessage = "Please enter integer between {0} - {1}: ";
        private const string ElementNumberInputMessage = "Enter the number of elements in the array: ";
        private const string SequenceElementInputMessage = "Enter an integer number. {0} remaining: ";
        private const string MinValueResultMessage = "The minimim element in the sequence: {0} ";
        
        public static void Main(string[] args)
        {
            DisplayText(ElementNumberInputMessage);
            var elementsNumber = GetValidInt(Console.ReadLine(), 1, int.MaxValue);
            var inputSequence = GetInputSequence(elementsNumber);
            DisplayText(string.Format(MinValueResultMessage, GetMinValue(inputSequence)));
        }

        /// <summary>
        /// Sorting the array and get first element
        /// </summary>
        private static int GetMinValue(int[] inputSequence)
        {
            Array.Sort(inputSequence);
            return inputSequence[0];
        }

        /// <summary>
        /// Get elements of the array from console
        /// </summary>
        private static int[] GetInputSequence(int elementsNumber)
        {
            var inputSequence = new int[elementsNumber];

            for (var i = 0; i < inputSequence.Length; i++)
            {
                DisplayText(string.Format(SequenceElementInputMessage, elementsNumber - i));
                inputSequence[i] = GetValidInt(Console.ReadLine(), int.MinValue, int.MaxValue);
            }

            return inputSequence;
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