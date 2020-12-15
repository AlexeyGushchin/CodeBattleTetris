/*-
 * #%L
 * Codenjoy - it's a dojo-like platform from developers to developers.
 * %%
 * Copyright (C) 2018 Codenjoy
 * %%
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public
 * License along with this program.  If not, see
 * <http://www.gnu.org/licenses/gpl-3.0.html>.
 * #L%
 */

using System.Collections.Generic;
using System.Linq;
using TetrisClient.MyLogic;

namespace TetrisClient
{
    /// <summary>
    /// В этом классе находится логика Вашего бота
    /// </summary>
    internal class YourSolver : AbstractSolver
	{
		public YourSolver(string server)
			: base(server)
		{
		}

		bool firstLvlFlag = true;
		bool L_Level = false;
		/// <summary>
		/// Этот метод вызывается каждый игровой тик
		/// </summary>
		protected internal override Command Get(Board board)
		{
			
			var landscape = new Landscape(board, L_Level);

			if (firstLvlFlag)
            {
				if (board.GetFutureFigures().All(i => i == Element.YELLOW))
					return landscape.GetFirstLevelLogicCommand();
				else
					firstLvlFlag = false;
			}

            if (!L_Level)
            {
				if (board.GetFutureFigures().Any(i => i == Element.ORANGE))
					L_Level = true;
            }

			var figureType = board.GetCurrentFigureType();

			var info = landscape.GetMoveFigureInfo(figureType);

			var moveDelta = landscape.GetDelta(info.turgetIndex, info.turningLosses);

			if (moveDelta == 0 && info.rotate == Direction.Up)
            {
				return Command.DOWN;
            }

			var direction = landscape.GetDirection(info.turgetIndex, info.turningLosses);

			if (info.rotate != Direction.Up)
            {
				return MyFigureRotator.Rotate(info.rotate).Then(FigureShifter.Move(moveDelta, direction));
			}
            else
            {
				return FigureShifter.Move(moveDelta, direction);
				
			}

		}

	}
}
