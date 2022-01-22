using System;

namespace Task1_RandomMatrix
{
    internal static class Program
    {
        private const string RowNumberInputMessage = "Please enter the amount of rows in matrix: ";
        private const string ColumnNumberInputMessage = "Please enter the amount of columns in matrix: ";
        private const string WarningInputMessage = "Please enter integer between {0} - {1}: ";
        private const string ResultMatrixMessage = "The result matrix: ";
        private const string ResultSumMessage = "The sum of all elements in result matrix: {0}";
        private const int MaxRowNumber = 15;
        private const int MaxColumnNumber = 15;
        private const int MaxRandomValue = 999;
        
        public static void Main(string[] args)
        {
            DisplayText(RowNumberInputMessage);
            var rowCount = GetValidInt(Console.ReadLine(), 1, MaxRowNumber);
            DisplayText(ColumnNumberInputMessage);
            var columnCount = GetValidInt(Console.ReadLine(), 1, MaxColumnNumber);
            
            var randomMatrix = GenerateRandomMatrix(rowCount, columnCount);
            DisplayText(ResultMatrixMessage);
            ShowMatrix(randomMatrix);

            var sum = GetSum(randomMatrix);
            DisplayText(string.Format(ResultSumMessage, sum));
        }

        private static int GetSum(int[,] resultMatrix)
        {
            var sum = 0;
            foreach (var element in resultMatrix)
            {
                sum += element;
            }

            return sum;
        }

        private static int[,] GenerateRandomMatrix(int rowCount, int columnCount)
        {
            var randomMatrix = new int[rowCount, columnCount];
            var randomizer = new Random();
            // It ia possible to do all actions in on for but method approach is better
            for (var i = 0; i < randomMatrix.GetLongLength(0); i++)
            {
                for (var j = 0; j < randomMatrix.GetLength(1); j++)
                {
                    randomMatrix[i, j] = randomizer.Next(0, MaxRandomValue + 1);
                }
            }

            return randomMatrix;
        }
        
        /// <summary>
        /// To validate integer value from Console
        /// </summary>
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

        private static void ShowMatrix(int[,] resultMatrix)
        {
            for (var i = 0; i < resultMatrix.GetLongLength(0); i++)
            {
                for (var j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    DisplayElement(resultMatrix[i,j]);
                }
                EmptyString();
            }
        }

        
        private static void EmptyString()
        {
            Console.WriteLine();
        }
        
        private static void DisplayText(string text)
        {
            Console.WriteLine(text);
        }
        
        private static void DisplayElement(int matrixElement)
        {
            Console.Write($"{matrixElement, 3} ");
        }
    }
}