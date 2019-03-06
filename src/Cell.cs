
using System.Collections.Generic;
using System.Linq;
using System;
namespace SokobanGen
{
    public enum Color{ RED, ORANGE, YELLOW, GREEN, BLUE, PURPLE}
    public enum Kind{GOAL, PIECE, OBSTACLE}
    public enum Direction{UP, DOWN, RIGHT, LEFT}
    public class Cell
    {
        protected Vec pos;
        protected Game game;
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
    }

}