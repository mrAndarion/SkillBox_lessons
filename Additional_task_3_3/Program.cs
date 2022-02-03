using System;

namespace Additional_task_3_3
{
    internal static class Program
    {
        private const string FirstRowCountInputMessage = "Please enter the amount of rows in first multiplier matrix: ";
        private const string FirstColumnCountInputMessage = "Please enter the amount of columns in first multiplier matrix: ";
        private const string SecondRowNumberInputMessage = "Row count in the second matrix set to {0} because should be equal row count in the first matrix ";
        private const string SecondColumnCountInputMessage = "Please enter the amount of columns in second matrix: ";
        private const string WarningInputMessage = "Please enter integer between {0} - {1}: ";
        private const string FirstMatrixMessage = "First multiplier matrix generated: ";
        private const string SecondMatrixMessage = "Agreed matrix matrix generated: ";
        private const string ResultMatrixMessage = "The result matrix: ";
        private const int MaxRowNumber = 15;
        private const int MaxColumnNumber = 15;
        private const int MaxRandomValue = 9;
        
        public static void Main(string[] args)
        {
            DisplayText(FirstRowCountInputMessage);
            var firstRowCount = GetValidInt(Console.ReadLine(), 1, MaxRowNumber);
            DisplayText(FirstColumnCountInputMessage);
            var firstColumnCount = GetValidInt(Console.ReadLine(), 1, MaxColumnNumber);
            
            DisplayText(string.Format(SecondRowNumberInputMessage, firstColumnCount));
            DisplayText(SecondColumnCountInputMessage);
            var secondColumnCount = GetValidInt(Console.ReadLine(), 1, MaxColumnNumber);
            
            var firstMatrix = GenerateRandomMatrix(firstRowCount, firstColumnCount);
            DisplayText(FirstMatrixMessage);
            ShowMatrix(firstMatrix);
            var secondMatrix = GenerateRandomMatrix(firstColumnCount, secondColumnCount);
            DisplayText(SecondMatrixMessage);
            ShowMatrix(secondMatrix);
            
            var resultMatrix = GetResultMatrix(firstMatrix, secondMatrix);
            DisplayText(ResultMatrixMessage);
            ShowMatrix(resultMatrix);
        }

        /// <summary>
        /// Multiply first matrix on second matrix
        /// </summary>
        private static long[,] GetResultMatrix(long[,] firstMatrix, long[,] secondMatrix)
        {
            var resultMatrix = new long[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (var i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    for (var k = 0; k < firstMatrix.GetLength(1); k++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Generate random matrix
        /// </summary>
        private static long[,] GenerateRandomMatrix(int rowCount, int columnCount)
        {
            var randomMatrix = new long[rowCount, columnCount];
            var randomizer = new Random();
            
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

        private static void ShowMatrix(long[,] resultMatrix)
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
        
        private static void DisplayElement(long matrixElement)
        {
            Console.Write($"{matrixElement, 6} ");
        }
    }
}