using System;
using System.Text.RegularExpressions;

namespace Task1_SplitString
{
    internal static class Program
    {
        private const string StringInputMessage = "Enter string of words separated by spaces";
        private const string ResultWordsMessage = "Words in input string:";
        private const string StringFormat = "^[a-zA-Z ]+$";
        private const char StringSeparator = ' ';

        public static void Main(string[] args)
        {
            var inputString = GetStringFromConsole();
            var wordsArray = SplitStringToStringArray(inputString);
            DisplayText(ResultWordsMessage);
            DisplayArrayWithoutSpaces(wordsArray);
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
            } while (string.IsNullOrEmpty(inputString) || !Regex.IsMatch(inputString, StringFormat));

            return inputString;
        }

        /// <summary>
        /// Split string to string array
        /// </summary>
        private static string[] SplitStringToStringArray(string inputString) => inputString.Split(StringSeparator);

        /// <summary>
        /// Show string array in console without empty strings
        /// </summary>
        private static void DisplayArrayWithoutSpaces(string[] wordsArray)
        {
            foreach (var word in wordsArray)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    DisplayText(word);
                }
            }
        }

        /// <summary>
        /// Show string in console
        /// </summary>
        private static void DisplayText(string text) => Console.WriteLine(text);
    }
}