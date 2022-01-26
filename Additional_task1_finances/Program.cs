using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_task1_finances
{
    internal static class Program
    {
        private const int NumberOfMonths = 12;
        private const int MaxRandomNumber = 15;
        private const int ToThousands = 10000;
        private const string MonthForTable = "Month";
        private const string IncomeForTable = "Income, $";
        private const string ExpensesForTable = "Expenses, $";
        private const string ProfitForTable = "Profit, $";
        private const string WorstProfitMessage = "Numbers of months with worst profit: ";
        private const string PositiveProfitMessage = "The amount of months with positive profit: ";

        public static void Main(string[] args)
        {
            var incomeArray = GetRandomArray();
            var expensesArray = GetRandomArray();
            var profitList = GetProfitList(incomeArray, expensesArray);
            DisplayFinanceTable(incomeArray, expensesArray, profitList);
            
            DisplayText(WorstProfitMessage);
            DisplayWorstProfitMonthNumbers(profitList);
            
            DisplayText(PositiveProfitMessage);
            DisplayText(GetPositiveProfitMonthsCount(profitList).ToString());
            profitList.Clear();
        }

        /// <summary>
        /// Get amount of months with positive profit
        /// </summary>
        /// <param name="profitList"></param>
        /// <returns></returns>
        private static int GetPositiveProfitMonthsCount(List<ProfitPerMonth> profitList)
        {
            var count = profitList.Count(item => item.Profit > 0);
            return count;
        }
        
        /// <summary>
        /// Show worst profit months numbers
        /// </summary>
        private static void DisplayWorstProfitMonthNumbers(List<ProfitPerMonth> profitList)
        {
            var orderedProfitList = new List<ProfitPerMonth>(profitList.OrderBy(inc => inc.Profit));
            var count = 0;
            for (var i = 0; i < 3; i++)
            {
                if (count == NumberOfMonths)
                    break;
                DisplayNumber(orderedProfitList[count].NumberOfMonth);
                count++;
                while (orderedProfitList[count].Profit == orderedProfitList[count - 1].Profit && count < NumberOfMonths)
                {
                    DisplayNumber(orderedProfitList[count].NumberOfMonth);
                    count++;
                }
            }
            RemoveLastCommaFromConsole();
            orderedProfitList.Clear();
        }

        /// <summary>
        /// Show table in Console
        /// </summary>
        private static void DisplayFinanceTable(int[] incomeArray, int[] expensesArray, List<ProfitPerMonth> profitList)
        {
            DisplayText(string.Format($"{MonthForTable, 5}   {IncomeForTable, 12}   {ExpensesForTable, 12}   {ProfitForTable, 12}"));
            for (var i = 0; i < NumberOfMonths; i++)
            {
                DisplayText(string.Format($"{i + 1, 5}   {incomeArray[i], 12}   {expensesArray[i], 12}   {profitList[i].Profit, 12}"));
            }
        }
        
        /// <summary>
        /// Generate random array
        /// </summary>
        private static int[] GetRandomArray()
        {
            var randomArray = new int[NumberOfMonths];
            for (var i = 0; i < randomArray.Length; i++)
            {
                var randomizer = new Random();
                randomArray[i] = randomizer.Next(0, MaxRandomNumber) * ToThousands;
            }

            return randomArray;
        }

        /// <summary>
        /// Get profit list from incomeArray and expensesArray
        /// </summary>
        private static List<ProfitPerMonth> GetProfitList(int[] incomeArray, int[] expensesArray)
        {
            var profitList = new List<ProfitPerMonth>();
            for (var i = 0; i < NumberOfMonths; i++)
            {
                var profitPerMonth = new ProfitPerMonth
                {
                    NumberOfMonth = i + 1,
                    Profit = incomeArray[i] - expensesArray[i]
                };
                profitList.Add(profitPerMonth);
            }
            
            return profitList;
        }

        private static void DisplayText(string text)
        {
            Console.WriteLine(text);
        }
        
        private static void DisplayNumber(int number)
        {
            Console.Write($"{number}, ");
        }
        
        /// <summary>
        /// Remove last comma from the Console
        /// </summary>
        private static void RemoveLastCommaFromConsole()
        {
            Console.Write("\b");
            Console.Write("\b.");
            Console.WriteLine();
        }
        
        private struct ProfitPerMonth
        {
            public int NumberOfMonth;
            public int Profit;
        }
    }
}