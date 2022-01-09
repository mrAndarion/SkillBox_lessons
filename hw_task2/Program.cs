using System;

namespace hw_task2
{
    internal static class Program
    {
        private const string HelloMessage = "Hello ";
        private const string WorldMessage = "World";
        private const string ExclamationsMessage = "!!!";
        
        public static void Main(string[] args)
        {
            DisplayWord(HelloMessage);
            DisplayWord(WorldMessage);
            DisplayWord(ExclamationsMessage);
        }

        private static void DisplayWord(string text)
        {
            Console.Write(text);
        }
    }
}