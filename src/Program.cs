using System;
using System.Timers;
namespace SokobanGen
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Sokoban Evolutionary Algorithm 😎");
            var t =DateTime.Now;
            for (int i= 0; i <1;i++)
            {
                Game game = new Game();
                game.RandomGoals();
                game.RandomPieces();
                game.Display();
            }
            Console.WriteLine((DateTime.Now - t));
            
            

        }
    }
}






/*
┌───┬───┬───┬───┬───┬───┐
│   │ ⎔ │   │   │   │   │
├───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │ ⎔ │
├───┼───┼───┼───┼───┼───┤
│   │   │   │ ⎔ │   │ ■ │
├───┼───┼───┼───┼───┼───┤
│   │   │ ⎔ │ ■ │   │ ■ │
├───┼───┼───┼───┼───┼───┤
│   │ ■ │   │   │ ⎔ │   │
├───┼───┼───┼───┼───┼───┤
│ ⎔ │   │   │   │ ■ │   │
├───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │
├───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │
├───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │
├───┼───┼───┼───┼───┼───┤
│   │   │   │ ■ │   │   │
└───┴───┴───┴───┴───┴───┘
 */
