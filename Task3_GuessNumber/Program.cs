using System;

namespace Task3_GuessNumber
{
    internal static class Program
    {
        private const string WarningInputMessage = "Please enter integer between {0} - {1}: ";
        private const string MaxNumberInputMessage = "Enter max number which will be generated: ";
        private const string GameStartMessage = "The game number is generated. Let the game begins...";
        private const string GuessInputMessage = "Enter your guess or press Enter to exit (attempt {0}):";
        private const string GreaterMessage = "The game number is greater than yours. Try once more:";
        private const string LessMessage = "The game number is less than yours. Try once more:";
        private const string WinnerMessage = "Congratulations! Your guess is correct!";
        private const string EscapeMessage = "Better luck next time =(";
        
        public static void Main(string[] args)
        {
            DisplayText(MaxNumberInputMessage);
            var gameMaxNumber = GetValidInt(Console.ReadLine(), 0, int.MaxValue);
            var gameNumber = RandomizeGameNumber(gameMaxNumber);
            DisplayText(GameStartMessage);
            var gameResult = GuessNumberGame(gameNumber, gameMaxNumber);
            DisplayText(gameResult ? WinnerMessage : EscapeMessage);
        }

        /// <summary>
        /// The game main method. Returns true when user finished or false when user skip the game
        /// </summary>
        private static bool GuessNumberGame(int gameNumber, int gameMaxNumber)
        {
            var guessCounter = 1;
            while (true)
            {
                DisplayText(string.Format(GuessInputMessage, guessCounter));
                var inputString = Console.ReadLine();
                if (inputString == "")
                {
                    return false;
                }
                var guessNumber = GetValidInt(inputString, 0, gameMaxNumber);

                if (guessNumber > gameNumber)
                {
                    DisplayText(LessMessage);
                }
                else if (guessNumber < gameNumber)
                {
                    DisplayText(GreaterMessage);
                }
                else
                {
                    return true;
                }
                
                guessCounter++;
            }
        }
        
        /// <summary>
        /// Generate random number
        /// </summary>
        private static int RandomizeGameNumber(int gameMaxNumber)
        {
            var randomGenerator = new Random();
            return randomGenerator.Next(0, gameMaxNumber + 1);
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