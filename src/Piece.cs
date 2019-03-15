
using System.Collections.Generic;
using System.Linq;
using System;
namespace SokobanGen
{
    public class Piece : Cell
    {
        
        int invalidMoves = 0;
        protected List<Direction> movements;
    
        public Piece( int x, int y) : base(x, y)
        {
            kind = Kind.PIECE;
            movements = new List<Direction>();
            isBlocking = true;
        }
        Vec initialPos;
        bool isMoving = false;
        
        public void Move(Direction dir, int count=0)
        {
            Console.WriteLine("Moving {0} {1}", base.color.ToString(), dir.ToString()); 
            void EndMovement(bool invalidMove=false)
            {
                if(invalidMove){
                    invalidMoves++;
                    Console.WriteLine("Movement Finished. IniPos: {0} | FinalPos: {1}",initialPos, pos);
                    isMoving = false;
                    game.SwapPositions(initialPos, pos);
                    
                    return;
                }
            }

            if(!isMoving){
                initialPos = new Vec(pos.x, pos.y);
                Console.WriteLine("Initial pos is {0}.", initialPos);
            }
           //    public enum Direction{UP=0, DOWN=1 LEFT=2, RIGHT=3}
            bool isHor = (int)dir > 1;
            int sign = (int)dir % 2 == 0 ? -1 : 1;
            int next = (isHor? pos.x : pos.y) + sign;
            Vec nextPos = pos + new Vec(dir);
            int max = isHor ? game.width-1 : game.height-1;
            Console.WriteLine("Next is: " + next);
            if (next < 0 || next > max)
            {
                EndMovement(count>0);
                return;
            }
            Console.WriteLine("Next was: " + next);
            if (game.isBlockedPos(nextPos))
            {
                EndMovement(count>0);
                return;
            }
            movements.Add(dir);
            count++;
            pos = nextPos;
            Move(dir,count);

        }
    }
}