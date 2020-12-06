using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisClient.MyLogic
{
    public static class FigureShifter
    {
        public static Command Move(int delta, Direction direction)
        {
            if(direction == Direction.Left)
            {
                var command = Command.LEFT;
                for(int i = 0; i < delta - 1; i++)
                {
                    command = command.Then(Command.LEFT);
                }

                return command.Then(Command.DOWN);
            }
            else if (direction == Direction.Right)
            {
                var command = Command.RIGHT;
                for (int i = 0; i < delta - 1; i++)
                {
                    command = command.Then(Command.RIGHT);
                }

                return command.Then(Command.DOWN);
            }
            else return Command.DOWN;
        }
    }
}
