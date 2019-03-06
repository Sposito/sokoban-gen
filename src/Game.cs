
using System.Collections.Generic;
using System.Linq;
using System;
namespace SokobanGen
{
    public class Game{
        public readonly int width = 6;
        public readonly int height = 10;
        Cell[,] grid;
        Cell cache;
        int[] goalYPos;
        public Game()
        {
            

            grid = new Cell[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    grid[i,j] = new Cell(i, j );
                    grid[i,j].SetGame(this);
                }   
            }
            goalYPos = new int[width];
        }

        public void Display()
        {
            Console.WriteLine("┌" + String.Concat(Enumerable.Repeat("───┬", width-1)) + "───┐");
            
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

            string header = "┌" + String.Concat(Enumerable.Repeat("───┬", width-1)) + "───┐";
            void WriteRow(char[] input)
            {
                Console.Write("│");
                foreach (char c in input)
                {
                     
                }
                
            }
            
        }

        public void RandomGoals(){
            Random rnd = new Random();
            goalYPos = Enumerable.Range(0, width).OrderBy(x => rnd.Next()).ToArray();
        }

        public bool isBlockedPos(Vec vec){
            return grid[vec.x,vec.y].isBlocking;
        }

        public bool IsValidPos(Vec pos){
            return pos.x >= 0 || pos.y >= 0 || pos.x < width || pos.y < height;
        }
        public void SetCell(Cell cell, Vec pos){
            if(!IsValidPos(pos))
                return;
            
            grid[pos.x, pos.y] = cell;    
        }

        public bool SwapPositions(Vec a, Vec b){
            if( !(IsValidPos(a) && IsValidPos(b)) )
                return false;
            
            cache = grid[a.x, a.y];
            grid[a.x, a.y] = grid[b.x, b.y];
            grid[b.x, b.y] = cache;

            grid[a.x, a.y].SetPos(b);
            grid[b.x, b.y].SetPos(a);
            
            cache = null;
            return true;
        }
    }
}