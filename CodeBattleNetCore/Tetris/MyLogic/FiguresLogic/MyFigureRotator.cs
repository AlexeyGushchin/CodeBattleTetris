using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisClient.MyLogic
{
    public static class MyFigureRotator
    {
        public static Command Rotate(Direction direction)
        {
            if (direction == Direction.Left)
            {
                return Command.ROTATE_CLOCKWISE_270;
            }
            else if(direction == Direction.Right)
            {
                return Command.ROTATE_CLOCKWISE_90;
            }
            else if(direction == Direction.Down)
            {
                return Command.ROTATE_CLOCKWISE_180;
            }
            else
            {
                return Command.ROTATE_CLOCKWISE_180.Then(Command.ROTATE_CLOCKWISE_180);
            }

        }
    }
}
