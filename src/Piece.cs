
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
    
        }
        Vec initialPos;
        bool isMoving = false;
        public void Move(Direction dir, int count=0)
        {

            void EndMovement(bool invalidMove=false){
                if(invalidMove){
                    invalidMoves++;
                    game.SwapPositions(initialPos, pos);
                    isMoving = false;
                    return;
                    
                }

            }
            if(!isMoving){
                initialPos = pos;
            }
            bool isHor = (int)dir > 1;
            int sign = (int)dir % 2 == 0 ? 1 : -1;
            int next = isHor? pos.x : pos.y + sign;
            Vec nextPos = pos + new Vec(dir);
            int max = isHor ? game.width : game.height;

            if (next < 0 && next >= max)
            {
                EndMovement(count>0);
                return;
            }
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