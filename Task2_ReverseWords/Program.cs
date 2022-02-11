using System;
using System.Text.RegularExpressions;

namespace Task2_ReverseWords
{
    internal static class Program
    {
        private const string StringInputMessage = "Enter string of words separated by spaces";
        private const string ResultWordsMessage = "Reverse string:";
        private const string StringFormat = "^[a-zA-Z ]+$";
        private const char StringSeparator = ' ';

        public static void Main(string[] args)
        {
            var inputString = GetStringFromConsole();
            var reversString = ReverseString(inputString);
            DisplayText(ResultWordsMessage);
            DisplayText(reversString);
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
        /// Split string to string array reverse words and returns revers string
        /// </summary>
        private static string ReverseString(string inputString)
        {
            var wordsArray = inputString.Split(StringSeparator);
            
            return GetReverseString(wordsArray);
        }
        
        /// <summary>
        /// Revers string array and combine array to srting;
        /// </summary>
        private static string GetReverseString(string[] wordsArray)
        {
            var reverseString = "";
            for (var i = wordsArray.Length - 1; i >= 0; i--)
            {
                reverseString += wordsArray[i] + StringSeparator;
            }

            return reverseString;
        }

        /// <summary>
        /// Show string in console
        /// </summary>
        private static void DisplayText(string text) => Console.WriteLine(text);
    }
}