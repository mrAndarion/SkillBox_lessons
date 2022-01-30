using System;

namespace Additional_task_3_1
{
    internal static  class Program
    {
        private const string RowNumberInputMessage = "Please enter the amount of rows in matrix: ";
        private const string ColumnNumberInputMessage = "Please enter the amount of columns in matrix: ";
        private const string WarningInputMessage = "Please enter integer between {0} - {1}: ";
        private const string RandomMatrixMessage = "Random matrix generated: ";
        private const string MultiplierInputMessage = "Enter the multiplier number: ";
        private const string ResultMatrixMessage = "The result matrix: ";
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
            DisplayText(RandomMatrixMessage);
            ShowMatrix(randomMatrix);
            
            DisplayText(MultiplierInputMessage);
            var multiplier = GetValidInt(Console.ReadLine(), int.MinValue, int.MaxValue);

            var resultMatrix = GetResultMatrix(randomMatrix, multiplier);
            DisplayText(ResultMatrixMessage);
            ShowMatrix(resultMatrix);
        }

        /// <summary>
        /// Multiply matrix on the number
        /// </summary>
        private static int[,] GetResultMatrix(int[,] randomMatrix, int multiplier)
        {
            for (var i = 0; i < randomMatrix.GetLongLength(0); i++)
            {
                for (var j = 0; j < randomMatrix.GetLength(1); j++)
                {
                    randomMatrix[i, j] *= multiplier;
                }
            }

            return randomMatrix;
        }

        /// <summary>
        /// Generate random matrix
        /// </summary>
        private static int[,] GenerateRandomMatrix(int rowCount, int columnCount)
        {
            var randomMatrix = new int[rowCount, columnCount];
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
            Console.Write($"{matrixElement, 6} ");
        }
    }
}