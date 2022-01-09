using System;

namespace SkillBox_Lessons
{
    internal static class Program
    {
        private const string HelloWorldMessage = "Hello World!!!";
        public static void Main(string[] args)
        {
            DisplayText(HelloWorldMessage);
        }
        
        private static void DisplayText(string text)
        {
            Console.WriteLine(text);
        }
    }
}