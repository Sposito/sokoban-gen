using System;

namespace SokobanGen
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Sokoban Evolutionary Algorithm 😎");
            //Console.SetCursorPosition(0, 0);
            var a = "┌───┬───┬───┬───┬───┬───┐";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("┌───┬───┬───┬───┬───┬───┐");
            Console.WriteLine("│   │   │   │   │   │   │");
            Console.WriteLine("├───┼───┼───┼───┼───┼───┤");
            Console.WriteLine("│   │   │   │   │   │   │");
            Console.WriteLine("├───┼───┼───┼───┼───┼───┤");
            Console.WriteLine("│   │   │   │   │   │   │");
            Console.WriteLine("├───┼───┼───┼───┼───┼───┤");
            Console.WriteLine("│   │   │   │   │   │   │");
            Console.WriteLine("├───┼───┼───┼───┼───┼───┤");
            Console.WriteLine("│   │   │   │   │   │   │");
            Console.WriteLine("├───┼───┼───┼───┼───┼───┤");
            Console.WriteLine("│   │   │   │   │   │   │");
            Console.WriteLine("├───┼───┼───┼───┼───┼───┤");
            Console.WriteLine("│   │   │   │   │   │   │");
            Console.WriteLine("├───┼───┼───┼───┼───┼───┤");
            Console.WriteLine("│   │   │   │   │   │   │");
            Console.WriteLine("├───┼───┼───┼───┼───┼───┤");
            Console.WriteLine("│   │   │   │   │   │   │");
            Console.WriteLine("├───┼───┼───┼───┼───┼───┤");
            Console.WriteLine("│   │   │   │   │   │   │");
            Console.WriteLine("└───┴───┴───┴───┴───┴───┘");
            Console.ResetColor();
            Console.WriteLine();
            Game game = new Game();
            

        }
    }
}
