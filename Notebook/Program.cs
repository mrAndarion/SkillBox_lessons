using System;

namespace Notebook
{
    internal static class  Program
    {
        // All unchangeable variables to const
        private const string Name = "Ivan";
        private const int Age = 32;
        private const int Height = 190;
        private const double ResultHistory = 73;
        private const double ResultMath = 66;
        private const double ResultRussian = 99;
        private const int SubjectsCount = 3;
        private const string OutputMessage = "All 3 types of output:";
        private const string ResultString = "Name: {0}, Age {1}, Height {2}, History {3}, Math {4}, Russian {5}, " +
                                            "Average {6}";
        
        /// <summary>
        /// XML comment demo. Main class
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //const could be used in method itself, so it is for example
            var averageScore = GetAverage(ResultHistory, ResultMath, ResultRussian);
            //One symbol after ,
            var formattedAverageScore = averageScore.ToString("0.0");
            DisplayText(OutputMessage);
            //method 1
            DisplayText("Name: " + Name);
            DisplayText("Age: " + Age);
            DisplayText("Height:" + Height);
            DisplayText("History result: " + ResultHistory);
            DisplayText("Math result: " + ResultMath);
            DisplayText("Russian result: " + ResultRussian);
            DisplayText("Average score: " + formattedAverageScore);
            DisplayText();
            //method 2 centered
            var centerX = (Console.WindowWidth / 2);
            var countStrings = 10;
            Console.SetCursorPosition(centerX,countStrings); // if it is needed to display text in absolute
                                                             // center of console another variable centerY is needed
            DisplayText($"Name: {Name}");
            Console.SetCursorPosition(centerX, ++countStrings);
            DisplayText($"Age: {Age}");
            Console.SetCursorPosition(centerX, ++countStrings);
            DisplayText($"Height: {Height}");
            Console.SetCursorPosition(centerX, ++countStrings);
            DisplayText($"History result: {ResultHistory}");
            Console.SetCursorPosition(centerX, ++countStrings);
            DisplayText($"Math result: {ResultMath}");
            Console.SetCursorPosition(centerX, ++countStrings);
            DisplayText($"Russian result: {ResultRussian}");
            Console.SetCursorPosition(centerX, ++countStrings);
            DisplayText($"Average score: {formattedAverageScore}");
            Console.SetCursorPosition(centerX, ++countStrings);
            DisplayText();
            //Method 3 in one string for example
            DisplayText(string.Format(ResultString, Name, Age, Height, ResultHistory, ResultMath, ResultRussian, 
                formattedAverageScore));
        }
        
        /// <summary>
        /// Method for Display text
        /// </summary>
        /// <param name="text"></param>
        private static void DisplayText(string text)
        {
            Console.WriteLine(text);
        }
        
        /// <summary>
        /// Empty string output
        /// </summary>
        private static void DisplayText()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Get average score
        /// </summary>
        /// <param name="resultMath"></param>
        /// <param name="resultHistory"></param>
        /// <param name="resultRussian"></param>
        /// <returns></returns>
        private static double GetAverage(double resultHistory, double resultMath, double resultRussian)
        {
            return (resultHistory + resultMath + resultRussian) / SubjectsCount;
        }
    }
}