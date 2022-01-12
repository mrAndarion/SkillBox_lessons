using System;
using System.Collections.Generic;

namespace Task2_Blackjack
{
    internal static class Program
    {
        private static readonly List<string> CardValues = new List<string> {"2", "3", "4", "5", "6", "7", "8",
            "9", "10", "J", "Q", "K", "T"};
        private const string WarningInputMessage = "Please enter integer between {0} - {1}: ";
        private const string CardsAmountMessage = "Input the number of cards you have on your hands: ";
        private const string CardsValueMessage = "Enter your card (available options 2-10, J, Q, K, T) and press Enter." +
                                                 " Cards remaining {0}: ";
        private const string ResultMessage = "The sum of your cards: {0}";
        private const int MinCardAmount = 0;
        private const int MaxCardAmount = 50;
        private const int ImageCardIntValue = 10;
        private const int AceCardIntValue = 11;
        
        public static void Main(string[] args)
        {
            DisplayText(CardsAmountMessage);
            var cardsCount = GetValidInt(Console.ReadLine(), MinCardAmount, MaxCardAmount);
            var cardsSum = 0;
            
            for (var i = cardsCount; i > 0; i--)
            {
                var cardString = ValidateCardValue(i);
                var cardValue = ConvertCardValueToInt(cardString);
                cardsSum += cardValue;
            }
            
            DisplayText(string.Format(ResultMessage, cardsSum));
        }

        private static int ConvertCardValueToInt(string cardValue)
        {
            switch (cardValue)
            {
                case "J":
                    return ImageCardIntValue;
                case "Q":
                    return ImageCardIntValue;
                case "K":
                    return ImageCardIntValue;
                case "T":
                    return AceCardIntValue;
                default:
                    return int.Parse(cardValue);
            }
        }
        
        private static string ValidateCardValue(int count)
        {
            string cardString;
            do
            {
                DisplayText(string.Format(CardsValueMessage, count));
                cardString = Console.ReadLine();
            } while (!CardValues.Contains(cardString));

            return cardString;
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