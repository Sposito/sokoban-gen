
using System.Collections.Generic;
using System.Linq;
using System;
namespace SokobanGen
{
    public class Game{
        public   int width = 6;
        public   int height = 10;
        Cell[] _grid ;
        Cell cache;
        int[] goalYPos;
        public Game()
        {
            _grid = new Cell[width * height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    SetGrid(i,j,new Cell(i, j ));
                    GetGrid(i,j).SetGame(this);
                }   
            }
            goalYPos = new int[width];
        }
       
       Cell GetGrid(int x, int y)
       {
           return _grid[y * width + x];
       }

       void SetGrid( int x, int y, Cell cell)
       {
           _grid[y * width + x] = cell;
       }

       readonly Dictionary <Color,ConsoleColor> colorDict = new Dictionary<Color, ConsoleColor>
        {
            [Color.NONE] = Console.ForegroundColor,
            [Color.RED] = ConsoleColor.Red,
            [Color.ORANGE] = ConsoleColor.DarkYellow,
            [Color.YELLOW] = ConsoleColor.Yellow,
            [Color.GREEN] = ConsoleColor.Green,
            [Color.BLUE] = ConsoleColor.Cyan,
            [Color.PURPLE] = ConsoleColor.DarkMagenta
            
        }; 
        public void Display()
        {
            
            string header = "┌" + String.Concat(Enumerable.Repeat("───┬", width-1)) + "───┐";
            Console.WriteLine(header);
            for (int i = 0 ; i < height; i++)
            {
                Console.Write("│");
                for (int j = 0 ; j < width; j++)
                {
                    Console.ForegroundColor = colorDict[GetGrid(j,i).color];
                    Console.Write(" {0} ",GetGrid(j,i).GetChar() );
                    Console.ResetColor();
                    Console.Write("│");
                }
                if(i < height -1) 
                    Console.Write("\n├───┼───┼───┼───┼───┼───┤");
                Console.Write("\n"); 
            }
            Console.WriteLine("└" + String.Concat(Enumerable.Repeat("───┴", width-1)) + "───┘");     
        }

        public void RandomGoals(){
            Random rnd = new Random();
            goalYPos = Enumerable.Range(0, width).OrderBy(x => rnd.Next()).ToArray();
            for(int i = 0; i < width; i++)
            {
                Goal goal = new Goal(i, goalYPos[i]);
                goal.color = (Color)i;
                SetGrid(goal.X, goal.Y, goal);
            }
        }

        public void RandomPieces(){
            var empty =_grid.Where(cell => cell.kind == Kind.EMPTY);
            Random rnd = new Random();
            var rndEmpty = empty.OrderBy(x => rnd.Next()).ToArray();
            
            for(int i = 0; i < width; i++){
                int x = rndEmpty[i].X;
                int y = rndEmpty[i].Y;
                Piece piece = new Piece(x,y);
                piece.SetGame(this);
                piece.color = (Color)i;
                SetGrid(x, y, piece);
            }     
        }

        public bool isBlockedPos(Vec vec){
            return GetGrid(vec.x,vec.y).isBlocking;
        }

        public bool IsValidPos(Vec pos){
            return pos.x >= 0 || pos.y >= 0 || pos.x < width || pos.y < height;
        }
        public void SetCell(Cell cell, Vec pos){
            if(!IsValidPos(pos))
                return;
            
            SetGrid(pos.x, pos.y,  cell);    
        }

        public bool SwapPositions(Vec a, Vec b){
            if( !(IsValidPos(a) && IsValidPos(b)) )
                return false;
            
            cache = GetGrid(a.x, a.y);
            SetGrid(a.x, a.y, GetGrid(b.x, b.y));
            SetGrid(b.x, b.y, cache);

            GetGrid(a.x, a.y).SetPos(b);
            GetGrid(b.x, b.y).SetPos(a);
            
            cache = null;
            return true;
        }
    }
}