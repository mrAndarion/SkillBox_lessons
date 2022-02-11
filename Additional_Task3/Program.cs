using System;
using System.Text.RegularExpressions;

namespace Additional_Task3
{
    internal static class Program
    {
        private const string StringInputMessage = "Enter string of words separated by spaces or a single word";
        private const string ResultWordsMessage = "Result text without repeating symbols:";
        private const string InputFormat = "^[a-zA-Z ]+$";
        
        public static void Main(string[] args)
        {
            var inputString = GetStringFromConsole();
            var resultString = RemoveRepeatingSymbols(inputString);
            DisplayText(ResultWordsMessage);
            DisplayText(resultString);
        }

        /// <summary>
        /// Remove repeating symbols from input string
        /// </summary>
        private static string RemoveRepeatingSymbols(string inputString)
        {
            var count = 1;
            var resultString = "";
            for (var i = 1; i < inputString.Length; i++)
            {
                if (char.ToLower(inputString[i]) == char.ToLower(inputString[i - 1]))
                {
                    count++;
                    continue;
                }

                resultString += inputString[i - 1];
                inputString = inputString.Substring(count);

                count = 1;
                i = 0;
            }

            resultString += inputString[inputString.Length - 1];

            return resultString;
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

        private static void DisplayText(string text) => Console.WriteLine(text);
    }
}