using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Additional_Task2_2_MaxWords
{
    internal static class Program
    {
        private const string StringInputMessage = "Enter string of words separated by spaces, \",\" or \".\"";
        private const string ResultWordsMessage = "Words with max length:";
        private const string StringFormat = "^[a-zA-Z,. ]+$";
        private static readonly string[] StringSeparator = {" ", "," ,"."};

        public static void Main(string[] args)
        {
            var inputString = GetStringFromConsole();
            var sortedWordsList = SplitStringToOrderedList(inputString);
            DisplayText(ResultWordsMessage);
            DisplayMaxLengthWords(sortedWordsList);
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
        /// Split string and convert to ordered list
        /// </summary>
        private static List<string> SplitStringToOrderedList(string inputString)
        {
            var wordsArray = inputString.Split(StringSeparator, StringSplitOptions.RemoveEmptyEntries);
            var wordsList = ConvertStringArrayToListWithoutSpaces(wordsArray);
            
            return wordsList.OrderByDescending(x => x.Length).ToList();
        }

        /// <summary>
        /// String array to list excluding empty strings
        /// </summary>
        private static List<string> ConvertStringArrayToListWithoutSpaces(string[] wordsArray)
        {
            var wordsList = new List<string>();
            foreach (var word in wordsArray)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    wordsList.Add(word);
                }
            }

            return wordsList;
        }

        /// <summary>
        /// Show string array in console without empty strings
        /// </summary>
        private static void DisplayMaxLengthWords(List<string> sortedList)
        {
            foreach (var word in sortedList)
            {
                if (word.Length < sortedList[0].Length) break;
                DisplayText(word);
            }
        }

        /// <summary>
        /// Show string in console
        /// </summary>
        private static void DisplayText(string text) => Console.WriteLine(text);
    }
}