using System;
using System.Text.RegularExpressions;

namespace Additional_Task_4
{
    internal static class Program
    {
        private const string StringInputMessage = "Enter sequence of numbers devided by spaces (at least 3 elements required):";
        private const string TooFewElementsMessage = "At least 3 elements required";
        private const string ArithmeticProgressionResultMessage = "Arithmetic progression";
        private const string GeometricProgressionResultMessage = "Geometric progression";
        private const string StaticProgressionResultMessage = "Static arithmetic and geometric progression";
        private const string NotProgressionResultMessage = "Nore arithmetic or geometric progressions";
        private const string InputFormat = "^[1-9 .-]+$";
        private static readonly string[] SpaceSeparator = {" "};
        
        public static void Main(string[] args)
        {
            var inputString = GetStringFromConsole();
            decimal[] sequence;
            
            try
            {
                sequence = StringToDecimalArray(inputString);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            if (IsTooFewElements(sequence))
            {
                DisplayText(TooFewElementsMessage);
                return;
            }

            var isArithmeticProgression = CheckArithmeticProgression(sequence);
            var isGeometricProgression = CheckGeometricProgression(sequence);

            DisplayResult(isArithmeticProgression, isGeometricProgression);
        }

        /// <summary>
        /// Check that sequence is geometric progression
        /// </summary>
        private static bool CheckGeometricProgression(decimal[] sequence)
        {
            var denominator = sequence[1] / sequence[0];
            for (var i = 2; i < sequence.Length; i++)
            {
                if (sequence[i] != sequence[i - 1] * denominator)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Check that sequence is arithmetic progression
        /// </summary>
        private static bool CheckArithmeticProgression(decimal[] sequence)
        {
            var diff = sequence[1] - sequence[0];
            for (var i = 2; i < sequence.Length; i++)
            {
                if (sequence[i] != sequence[i - 1] + diff)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Check that more then 2 elements entered
        /// </summary>
        private static bool IsTooFewElements(decimal[] sequence)
        {
            return sequence.Length <= 2;
        }

        private static decimal[] StringToDecimalArray(string inputString)
        {
            var stringArray = inputString.Split(SpaceSeparator, StringSplitOptions.RemoveEmptyEntries);
            var decimalArray = Array.ConvertAll(stringArray, decimal.Parse);
            
            return decimalArray;
        }
        
        /// <summary>
        /// Get string from console
        /// </summary>
        private static string GetStringFromConsole()
        {
            string inputString;
            do
            {
                DisplayText(StringInputMessage);
                inputString = Console.ReadLine();
            } while (string.IsNullOrEmpty(inputString) || !Regex.IsMatch(inputString, InputFormat));

            return inputString;
        }

        /// <summary>
        /// Display result message to console
        /// </summary>
        private static void DisplayResult(bool isArithmeticProgression, bool isGeometricProgression)
        {
            if (isArithmeticProgression && isGeometricProgression)
            {
                DisplayText(StaticProgressionResultMessage);
                return;
            }

            if (isArithmeticProgression)
            {
                DisplayText(ArithmeticProgressionResultMessage);
                return;
            }

            if (isGeometricProgression)
            {
                DisplayText(GeometricProgressionResultMessage);
                return;
            }
            
            DisplayText(NotProgressionResultMessage);
        }

        private static void DisplayText(string text) => Console.WriteLine(text);
    }
}