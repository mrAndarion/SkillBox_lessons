using System;
using System.Collections.Generic;

namespace Additional_task_3_2
{
    internal static  class Program
    {
        private static readonly List<string> AvailableOperators = new List<string> {"+", "-"};
        private const string RowNumberInputMessage = "Please enter the amount of rows in both matrix: ";
        private const string ColumnNumberInputMessage = "Please enter the amount of columns both matrix: ";
        private const string WarningInputMessage = "Please enter integer between {0} - {1}: ";
        private const string FirstMatrixGeneratedMessage = "First matrix generated: ";
        private const string SecondMatrixGeneratedMessage = "Second matrix generated: ";
        private const string OperatorInputMessage = "Please enter the operator (available options: + or -): ";
        private const string ResultMatrixMessage = "The result matrix: ";
        private const string UnknownOperatorMessage = "{0} is unknown operator.";
        private const int MaxRowNumber = 15;
        private const int MaxColumnNumber = 15;
        private const int MaxRandomValue = 999;
        
        
        public static void Main(string[] args)
        {
            DisplayText(RowNumberInputMessage);
            var rowCount = GetValidInt(Console.ReadLine(), 1, MaxRowNumber);
            DisplayText(ColumnNumberInputMessage);
            var columnCount = GetValidInt(Console.ReadLine(), 1, MaxColumnNumber);
            
            var firstMatrix = GenerateRandomMatrix(rowCount, columnCount);
            DisplayText(FirstMatrixGeneratedMessage);
            ShowMatrix(firstMatrix);
            var secondMatrix = GenerateRandomMatrix(rowCount, columnCount);
            DisplayText(SecondMatrixGeneratedMessage);
            ShowMatrix(secondMatrix);

            var mathOperator = GetAndValidateOperator();
            int[,] resultMatrix;

            try
            { 
                resultMatrix = GetResultMatrix(firstMatrix, secondMatrix, mathOperator);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                return;
            }
            
            DisplayText(ResultMatrixMessage);
            ShowMatrix(resultMatrix);
        }

        /// <summary>
        /// Get result of addition or subtraction of two matrix
        /// </summary>
        private static int[,] GetResultMatrix(int[,] firstMatrix, int[,] secondMatrix, string mathOperator)
        {
            switch (mathOperator)
            {
                case ("+"):
                    return CalculateAdditionResultMatrix(firstMatrix, secondMatrix);
                case "-":
                    return CalculateSubtractionResultMatrix(firstMatrix, secondMatrix);
                
                default:
                    throw new FormatException(string.Format(UnknownOperatorMessage, mathOperator));
            }
        }

        /// <summary>
        /// Calculate the result of matrix addition
        /// </summary>
        private static int[,] CalculateAdditionResultMatrix(int[,] firstMatrix, int[,] secondMatrix)
        {
            var resultMatrix = new int[firstMatrix.GetLongLength(0), firstMatrix.GetLongLength(1)];
            for (var i = 0; i < resultMatrix.GetLongLength(0); i++)
            {
                for (var j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    resultMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                }
            }

            return resultMatrix;
        }
        
        /// <summary>
        /// Calculate the result of matrix subtraction
        /// </summary>
        private static int[,] CalculateSubtractionResultMatrix(int[,] firstMatrix, int[,] secondMatrix)
        {
            var resultMatrix = new int[firstMatrix.GetLongLength(0), firstMatrix.GetLongLength(1)];
            for (var i = 0; i < resultMatrix.GetLongLength(0); i++)
            {
                for (var j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    resultMatrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
                }
            }

            return resultMatrix;
        }
        
        /// <summary>
        /// Get operator from console with validation
        /// </summary>
        private static string GetAndValidateOperator()
        {
            string inputOperator;
            do
            {
                DisplayText(OperatorInputMessage);
                inputOperator = Console.ReadLine();
            } while (!AvailableOperators.Contains(inputOperator));

            return inputOperator;
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