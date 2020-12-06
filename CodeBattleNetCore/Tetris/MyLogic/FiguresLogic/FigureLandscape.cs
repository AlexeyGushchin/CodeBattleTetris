using System;
using System.Collections.Generic;
using System.Text;
using TetrisClient.MyLogic.Figures;

namespace TetrisClient.MyLogic
{
    public class FigureLandscape
    {
        public int[] landscape;
        public Direction rotate;
        public int _turningLoses;

        public FigureLandscape(Direction rotateMode, int turningLoses, params int[] arr)
        {
            rotate = rotateMode;
            _turningLoses = turningLoses;
            landscape = arr;
        }
    }
}
