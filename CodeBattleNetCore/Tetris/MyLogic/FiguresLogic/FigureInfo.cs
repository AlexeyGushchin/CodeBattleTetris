using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisClient
{
    public struct FigureInfo
    {
        public int turgetIndex;
        public Direction rotate;
        public int turningLosses;

        
    }

    public struct SquareInfo
    {
        public int delta;
        public Direction direction;
    }
}
