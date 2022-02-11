using System;

namespace Additional_task_5_Ackerman
{
    internal static class Program
    {
        public static void Main()
        {
            var result = Ackerman(1, 2);
            Console.WriteLine($"A(1, 2) = {result}");
            result = Ackerman(2, 5);
            Console.WriteLine(($"A(2, 5) = {result}"));
        }

        /// <summary>
        /// Ackerman function recursion
        /// </summary>
        private static long Ackerman(long n, long m)
        {
            if (n > 0)
            {
                if (m > 0)
                    return Ackerman(n - 1, Ackerman(n, m - 1));
                return Ackerman(n - 1, 1);
            }

            return m + 1;
        }
    }
}