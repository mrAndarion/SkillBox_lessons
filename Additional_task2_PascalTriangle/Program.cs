using System;

namespace Additional_task2_PascalTriangle
{
    internal static class Program
    {
        private const string WarningInputMessage = "Please enter integer between {0} - {1}: ";
        private const string RowCountInputMessage = "Enter the number of rows of Pascal Triangle to show: ";
        private const int MaxRowCount = 25;

        public static void Main(string[] args)
        {
            DisplayText(RowCountInputMessage);
            var rowCount = GetValidInt(Console.ReadLine(), 1, MaxRowCount - 1);
            var pascalTriangle = GetPascalTriangle(rowCount);
            ShowPascalTriangle(pascalTriangle,rowCount);
        }

        /// <summary>
        /// Display Pascal triangle with padding calculation
        /// </summary>
        private static void ShowPascalTriangle(int[][] pascalTriangle, int rowCount)
        {
            double spaceCount = pascalTriangle[rowCount - 1].Length * 5;

            for (var i = 0; i < rowCount; i++)
            {
                double displayedCount = 0;
                do
                {
                    DisplaySpace();
                    displayedCount++;
                } while (displayedCount < spaceCount);

                spaceCount -= 4.5;

                for (var j = 0; j < pascalTriangle[i].Length; j++)
                {
                    DisplayElement(pascalTriangle[i][j]);
                }
                EmptyString();
            }
        }
        
        /// <summary>
        /// Get Pascal Triangle as jagged array
        /// </summary>
        private static int[][] GetPascalTriangle(int rowCount)
        {
            var pascalTriangle = new int[rowCount][];
            pascalTriangle[0] = new[] {1};
            pascalTriangle[1] = new[] {1, 1};

            for (var i = 2; i < rowCount; i++)
            {
                pascalTriangle[i] = new int[i + 1];
                pascalTriangle[i][0] = 1;
                for (var j = 1; j < pascalTriangle[i].Length - 1; j++)
                {
                    pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                }
                pascalTriangle[i][i] = 1;
            }

            return pascalTriangle;
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
        
        private static void DisplayElement(int element)
        {
            Console.Write($"{element, 6}   ");
        }
        
        private static void DisplaySpace()
        {
            Console.Write(" ");
        }
        
        private static void EmptyString()
        {
            Console.WriteLine();
        }
    }
}