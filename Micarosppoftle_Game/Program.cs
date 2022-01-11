using System;

namespace Micarosppoftle_Game
{
    internal static class Program
    {
        private const string WelcomeMessage = "Welcome to Micarosppoftle Strange Game:";
        private const string PlayersNumberInputMessage = "Input the number of players (available options 1-8)";
        private const string WarningInputMessage = "Please enter integer between {0} - {1}: ";
        private const string PlayerNameInputMessage = "Input name for player {0}: ";
        private const string GameNumberMinValueInputMessage = "Input MIN value for Game Number which will " +
                                                              "be generated automatically ";
        private const string GameNumberMaxValueInputMessage = "Input MAX value for Game Number which will " +
                                                              "be generated automatically ";
        private const string UserTryMaxValueInputMessage = "Input MAX value for User Move: ";
        private const string GameStartMessage = "Let the Game begins... ";
        private const string PlayerTurnMessage = "Player {0} turn: ";
        private const string CurrentNumberMessage = "Game number is {0}";
        private const string WinnerMessage = "Player {0} is victorious";
        private const string RoundNumberMessage = "Round {0}: ";
        private const string RematchMessage = "Wanna rematch? (input yes or no) ";
        private const string GameFinishedMessage = "Thank you for the game. Take care =) ";
        
        
        public static void Main()
        {
            while (true)
            {
                DisplayText(WelcomeMessage);
                
                DisplayText(PlayersNumberInputMessage);
                var playersNumber = GetValidInt(Console.ReadLine(), 2, 8);
                var playersNames = GetPlayersNames(playersNumber);

                DisplayText(GameNumberMinValueInputMessage);
                var gameNumberMinValue = GetValidInt(Console.ReadLine(), 1, int.MaxValue);
                DisplayText(GameNumberMaxValueInputMessage);
                var gameNumberMaxValue = GetValidInt(Console.ReadLine(), gameNumberMinValue, int.MaxValue);
                var gameNumber = RandomizeGameNumber(gameNumberMinValue, gameNumberMaxValue);

                DisplayText(UserTryMaxValueInputMessage);
                var userTry = GetValidInt(Console.ReadLine(), 1, int.MaxValue);

                var restart = CoopGame(playersNames, gameNumber, userTry);
                
                if (restart)
                {
                    continue;
                }

                DisplayText(GameFinishedMessage);
                return;
            }
        }
        
        private static bool CoopGame(string[] playersNames, int gameNumber, int userTry)
        {
            DisplayText(GameStartMessage);
            var winnerName = "";
            var roundNumber = 1;
            do
            {
                DisplayText(string.Format(RoundNumberMessage, roundNumber));
                foreach (var playerName in playersNames)
                {
                    DisplayText(string.Format(CurrentNumberMessage, gameNumber));
                    DisplayText(string.Format(PlayerTurnMessage, playerName));
                    var userTurn = GetValidInt(Console.ReadLine(), 1, 
                        gameNumber < userTry ? gameNumber : userTry);
                    gameNumber -= userTurn;
                    if (gameNumber == 0)
                    {
                        winnerName = playerName;
                        break;
                    }
                }
                
                roundNumber++;
            } while (gameNumber !=0);
            
            DisplayText(string.Format(WinnerMessage, winnerName));
            return DoRematch();
        }

        private static bool DoRematch()
        {
            string inputString;
            do
            {
                DisplayText(RematchMessage);
                inputString = Console.ReadLine();

            } while (string.IsNullOrEmpty(inputString) || inputString != "yes" && inputString != "no");

            return inputString == "yes";
        }

        private static int RandomizeGameNumber(int gameNumberMinValue, int gameNumberMaxValue)
        {
            var randomGenerator = new Random();
            return randomGenerator.Next(gameNumberMinValue, gameNumberMaxValue + 1);
        }

        private static string[] GetPlayersNames(int playersNumber)
        {
            var playersNames = new string[playersNumber];
            for (var i = 0; i < playersNumber; i++)
            {
                DisplayText(string.Format(PlayerNameInputMessage, i+1));
                playersNames[i] = Console.ReadLine();
            }

            return playersNames;
        }

        private static int GetValidInt(string inputString, int minValue, int maxValue)
        {
            int validInt;
            while (!(int.TryParse(inputString, out validInt)) || ((validInt < minValue) || (validInt > maxValue)))
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