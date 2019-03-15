
using System.Collections.Generic;
using System.Linq;
using System;
namespace SokobanGen
{
    public enum Color{ RED, ORANGE, YELLOW, GREEN, BLUE, PURPLE, NONE}
    public enum Kind{EMPTY, GOAL, PIECE, OBSTACLE}
    public enum Direction{UP=0, DOWN=1, LEFT=2, RIGHT=3}
    public class Cell
    {
        protected Vec pos;
        public int X { get { return pos.x; } }
        public int Y { get { return pos.y; } }
        protected Game game;
        public Color color = Color.NONE;
        public Kind kind  = Kind.EMPTY;
        public bool isBlocking = false;
        public bool isMovable = true;
        public Cell( int x, int y){
            this.pos = new Vec(x,y);
        }

        public void SetGame(Game game)
        {
            this.game = game;
        }
        public void SetPos(Vec pos){
            this.pos = pos;
        }

        public char GetChar(){
            if(kind == Kind.PIECE)
                return '■';
            if(kind == Kind.GOAL)
                return '⎔';
            if(kind == Kind.OBSTACLE)
                return 'X';
            
            return ' ';
        }  
    }

}