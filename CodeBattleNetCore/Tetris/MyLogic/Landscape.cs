using System;
using System.Collections.Generic;
using TetrisClient.MyLogic.Figures;

namespace TetrisClient.MyLogic
{
    public class Landscape
    {
        #region Prop
        private int boardSize { get; set; }
        private int startPosition { get; set; }
        private  int[] _landscape { get; set; }
        private List<int> badLowestPoint { get; set; }
        //private bool Flag { get; set; }
        private int LowestPoint 
        {
            get
            {
                int point;

                if(badLowestPoint.Count == 0)
                {
                    point = GetIndexOfLowestPoint();
                    badLowestPoint.Add(point);
                    return point;
                }
                else
                {
                    point = GetIndexOfLowestPointWithout(badLowestPoint);
                    badLowestPoint.Add(point);
                    return point;
                }
            }
        }
        public bool ReadyToStick
        {
            get
            {
                for(int i = 0; i < _landscape.Length - 2; i++)
                {
                    if (_landscape[i] < 4)
                        return false;
                }

                return true;
            }
        }
        private int Shift
        {
            get
            {
                return 0;
            }
        }

        #endregion

        #region Ctor

        public Landscape(Board board)
        {
            boardSize = board.Size;
            startPosition = boardSize / 2 - 1;
            badLowestPoint = new List<int>();

            SetLandscape(board);
        }

        #endregion

        #region Public Methods

        public Command GetFirstLevelLogicCommand()
        {
            var pointIndex = GetIndexOfLowestPoint();

            if (pointIndex == startPosition)
                return Command.DOWN;

            if (pointIndex < startPosition)
                return FigureShifter.Move(startPosition - pointIndex, Direction.Left);

            return FigureShifter.Move(pointIndex - startPosition, Direction.Right);


        }
        public FigureInfo GetMoveFigureInfo(Element element)
        {
            var landscapes = FigureLandscaper.GetFigureLandscapes(element);

            while (badLowestPoint.Count < boardSize - 1)
            {
                var lowestPointIndex = LowestPoint;

                foreach (var lnds in landscapes)
                {
                    if (TryPut(lnds.landscape, lowestPointIndex, out FigureInfo info))
                    {
                        info.rotate = lnds.rotate;
                        info.turningLosses = lnds._turningLoses;
                        return info;
                    }

                }
            }

            landscapes = FigureLandscaper.GetAlternate(element);
            badLowestPoint.Clear();

            while (badLowestPoint.Count < boardSize - 1)
            {
                var lowestPointIndex = LowestPoint;

                foreach (var lnds in landscapes)
                {
                    if (TryPut(lnds.landscape, lowestPointIndex, out FigureInfo info))
                    {
                        info.rotate = lnds.rotate;
                        info.turningLosses = lnds._turningLoses;
                        return info;
                    }

                }
            }

            return new FigureInfo() { rotate = Direction.Up, turgetIndex = 0, turningLosses = 0 };

        }
        public int GetDelta(int targetIndex, int turningLoses)
        {
            var position = startPosition - turningLoses;
            int delta = Math.Abs(position - targetIndex);
            return delta;
        }
        public Direction GetDirection(int targetIndex, int turningLoses)
        {
            var position = startPosition - turningLoses;

            if (targetIndex == position)
                return Direction.Down;
            if (targetIndex > position)
                return Direction.Right;
            if (targetIndex < position)
                return Direction.Left;
            return Direction.Up;
        }

        #endregion

        #region Private Methods
        private void SetLandscape(Board board)
        {
            _landscape = new int[board.Size];

            for (int x = 0; x < board.Size; x++)
            {
                for (int y = board.Size - 3; y >= 0; y--)
                {
                    if (!board.IsFree(x, y))
                    {
                        _landscape[x] = y + 1;
                        break;
                    }
                }
            }
        }
        private int GetIndexOfLowestPoint()
        {
            var minElem = _landscape[0];
            var minIndex = 0;

            for (int i = 1; i < _landscape.Length - 1; i++)
            {
                if (_landscape[i] < minElem)
                {
                    minElem = _landscape[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
        private int GetIndexOfLowestPointWithout(List<int> indexes)
        {

            var minElem = boardSize;
            var minIndex = boardSize;

            for (int i = 0; i < _landscape.Length - 1; i++)
            {
                if (indexes.Contains(i))
                    continue;

                if (_landscape[i] < minElem)
                {
                    minElem = _landscape[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
        private bool TryPut(int[] landscape, int index, out FigureInfo info)
        {
            var length = landscape.Length;

            var startIndex = GetStartIndex(length, index);
            var endIndex = GetEndIndex(length, index);



            for (; startIndex < endIndex + 1; startIndex++)
            {
                if (CanPut(startIndex, landscape))
                {
                    info = new FigureInfo() { turgetIndex = startIndex, rotate = Direction.Up, turningLosses = 0 };
                    return true;
                }
            }

            info = new FigureInfo();

            return false;

        }
        private int GetStartIndex(int length, int point)
        {
            point++;
            return point - length < 0 ? 0 : point - length;
        }
        private int GetEndIndex(int length, int point)
        { 
            return point + length > boardSize - Shift ? boardSize - length - Shift : point;
        }
        private bool CanPut(int index, int[] arr)
        {
            var firstSum = _landscape[index] + arr[0];
            for (int i = 0; i < arr.Length; i++, index++)
            {
                if (firstSum != _landscape[index] + arr[i])
                    return false;
            }

            return true;
        }
        #endregion














    }
}
