
using System.Collections.Generic;
using System.Linq;
using System;
namespace SokobanGen
{
    public  struct Vec{
        public readonly int x;
        public readonly int  y;
        public Vec(int x, int y){
            this.x = x;
            this.y = y;
        }
    

        public Vec(Direction dir)
        {
            //UP, DOWN, RIGHT, LEFT //    public enum Direction{UP=0, DOWN=1 LEFT=2, RIGHT=3}
            x =  (int)dir < 2 ? 0 : 1;
            x *= (int)dir % 2 == 0 ? -1: 1;
            y =  (int)dir < 2 ? 1 : 0;
            y *= (int)dir % 2 == 0 ? -1 : 1;
        }

        public static Vec operator +(Vec a, Vec b)
        {
            return new Vec(a.x + b.x, a.y + b.y);
        }

        public override string ToString(){
            return x + ", " + y;
        }
    }
}