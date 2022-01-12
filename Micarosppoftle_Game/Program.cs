using System;
using System.Threading;

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
        private const string WinnerMessage = "Player {0} is victorious!!!";
        private const string RoundNumberMessage = "Round {0}: ";
        private const string RematchMessage = "Wanna rematch? (input yes or no) ";
        private const string SelectDifficultyMessage = "Select AI difficulty (input easy or hard) ";
        private const string GameFinishedMessage = "Thank you for the game. Take care =) ";
        private const string AiName = "Computer";
        private const string EasyMode = "easy";
        private const string HardMode = "hard";
        private const string RematchYes = "yes";
        private const string RematchNo = "no";
        private const int MaxNameLength = 20;
        private const int ComputerMoveDelay = 1500;

        public static void Main()
        {
            while (true)
            {
                DisplayText(WelcomeMessage);
                
                DisplayText(PlayersNumberInputMessage);
                var playersNumber = GetValidInt(Console.ReadLine(), 1, 8);
                var playersNames = GetPlayersNames(playersNumber);

                DisplayText(GameNumberMinValueInputMessage);
                var gameNumberMinValue = GetValidInt(Console.ReadLine(), 1, int.MaxValue);
                DisplayText(GameNumberMaxValueInputMessage);
                var gameNumberMaxValue = GetValidInt(Console.ReadLine(), gameNumberMinValue, int.MaxValue);
                var gameNumber = RandomizeGameNumber(gameNumberMinValue, gameNumberMaxValue);

                DisplayText(UserTryMaxValueInputMessage);
                var userTry = GetValidInt(Console.ReadLine(), 1, int.MaxValue);
                
                var restart = playersNumber == 1 ? 
                    SoloGame(playersNames[0], gameNumber, userTry, SelectDifficulty()) 
                    : CoopGame(playersNames, gameNumber, userTry);
                
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
                    PlayerMove(ref gameNumber, playerName, ref userTry);
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
        
        private static bool SoloGame(string playerName, int gameNumber, int userTry, string gameMode)
        {
            DisplayText(GameStartMessage);
            string winnerName;
            var roundNumber = 1;
            
            do
            {
                DisplayText(string.Format(RoundNumberMessage, roundNumber));
                PlayerMove(ref gameNumber, playerName, ref userTry);
                if (gameNumber == 0)
                {
                    winnerName = playerName;
                    break;
                }

                if (gameMode == EasyMode)
                {
                    PcMoveEasy(ref gameNumber, AiName, ref userTry);
                }
                else
                {
                    PcMoveHard(ref gameNumber, AiName, ref userTry);
                }
                
                if (gameNumber == 0)
                {
                    winnerName = AiName;
                    break;
                }
                roundNumber++;
            } while (true);
            
            DisplayText(string.Format(WinnerMessage, winnerName));
            return DoRematch();
        }

        private static void PlayerMove(ref int gameNumber, string playerName, ref int userTry)
        {
            DisplayText(string.Format(CurrentNumberMessage, gameNumber));
            DisplayTurn(string.Format(PlayerTurnMessage, playerName));
            var userTurn = GetValidInt(Console.ReadLine(), 1, 
                gameNumber < userTry ? gameNumber : userTry);
            EmptyString();
            gameNumber -= userTurn;
        }
        
        private static void PcMoveEasy(ref int gameNumber, string playerName, ref int userTry)
        {
            DisplayText(string.Format(CurrentNumberMessage, gameNumber));
            DisplayTurn(string.Format(PlayerTurnMessage, playerName));
            var randomGenerator = new Random();
            var pcTurn = gameNumber < userTry ? randomGenerator.Next(1, gameNumber + 1) 
                : randomGenerator.Next(1, userTry + 1);
            Thread.Sleep(ComputerMoveDelay);
            DisplayTurn(pcTurn.ToString());
            EmptyString();
            gameNumber -= pcTurn;
        }
        
        private static void PcMoveHard(ref int gameNumber, string playerName, ref int userTry)
        {
            DisplayText(string.Format(CurrentNumberMessage, gameNumber));
            DisplayTurn(string.Format(PlayerTurnMessage, playerName));
            var randomGenerator = new Random();
            int pcTurn;
            if (gameNumber > userTry && gameNumber <= 2 * userTry && gameNumber != userTry + 1)
            {
                pcTurn = gameNumber - userTry - 1;
            }
            else
            {
                pcTurn = gameNumber <= userTry ? gameNumber : randomGenerator.Next(1, userTry + 1);
            }
            Thread.Sleep(ComputerMoveDelay);
            DisplayTurn(pcTurn.ToString());
            EmptyString();
            gameNumber -= pcTurn;
        }

        private static bool DoRematch()
        {
            string inputString;
            do
            {
                DisplayText(RematchMessage);
                inputString = Console.ReadLine();

            } while (string.IsNullOrEmpty(inputString) || inputString != RematchYes && inputString != RematchNo);

            return inputString == RematchYes;
        }
        
        private static string SelectDifficulty()
        {
            string inputString;
            do
            {
                DisplayText(SelectDifficultyMessage);
                inputString = Console.ReadLine();

            } while (string.IsNullOrEmpty(inputString) || inputString != EasyMode && inputString != HardMode);

            return inputString;
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
                do
                {
                    DisplayText(string.Format(PlayerNameInputMessage, i + 1));
                    playersNames[i] = Console.ReadLine();
                } while (string.IsNullOrEmpty(playersNames[i]) || playersNames[i].Length >= MaxNameLength);
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
        
        private static void DisplayTurn(string text)
        {
            Console.Write(text);
        }
        
        private static void EmptyString()
        {
            Console.WriteLine();
        }
    }
}