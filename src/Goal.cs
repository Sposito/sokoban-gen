
using System.Collections.Generic;
using System.Linq;
using System;
namespace SokobanGen
{
    public class Goal : Cell
    {
        int invalidMoves = 0;
        protected List<Direction> movements;
    
        public Goal( int x, int y) : base(x, y)
        {
            kind = Kind.GOAL;
        }
       
        
    }
}