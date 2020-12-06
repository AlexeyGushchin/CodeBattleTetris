using System;

namespace TetrisClient.MyLogic.Figures
{
    public static class FigureLandscaper
    {
        #region base
        public static FigureLandscape[] ILandscape = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Left, 1, new int[] {0, 0, 0, 0 }),
                        new FigureLandscape(Direction.Up, 0, new int[] {0}),
                    };

        public static FigureLandscape[] OLandscape = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Up, 0, new int[] {0, 0}),
                    };
        public static FigureLandscape[] TLandscape = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Down, 0, new int[] {-1, 0, -1}),
                        new FigureLandscape(Direction.Up, 0, new int[] {0, 0, 0}),
                        new FigureLandscape(Direction.Right, -1, new int[] {0, -1}),
                        new FigureLandscape(Direction.Left, 0, new int[] {-1, 0}),
                    };
        public static FigureLandscape[] SLandscape = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Up, 0, new int[] {0, 0, -1}),
                        new FigureLandscape(Direction.Left, 0, new int[] {-1, 0}),
                    };
        public static FigureLandscape[] ZLandscape = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Up, 0, new int[] {-1, 0, 0}),
                        new FigureLandscape(Direction.Left, 0, new int[] {0, -1}),
                    };
        public static FigureLandscape[] LLandscape = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Down, 1, new int[] {-2, 0}),
                        new FigureLandscape(Direction.Right, 1, new int[] {0, -1, -1}),
                        new FigureLandscape(Direction.Left, 1, new int[] {0, 0, 0}),
                        new FigureLandscape(Direction.Up, 0, new int[] {0, 0}),
                    };
        public static FigureLandscape[] JLandscape = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Down, -1, new int[] {0, -2}),
                        new FigureLandscape(Direction.Left, 0, new int[] {-1, -1, 0}),
                        new FigureLandscape(Direction.Right, 0, new int[] {0, 0, 0}),
                        new FigureLandscape(Direction.Up, 0, new int[] {0, 0}),
                    };

        #endregion

        #region alternate

        public static FigureLandscape[] IAlternate = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Left, 1, new int[] {0, 0, 0, 0 }),
                        new FigureLandscape(Direction.Up, 0, new int[] {0}),
                    };

        public static FigureLandscape[] OAlternate = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Up, 0, new int[] {-1, 0}),
                        new FigureLandscape(Direction.Up, 0, new int[] {0, -1}),

                        new FigureLandscape(Direction.Up, 0, new int[] {-2, 0}),
                        new FigureLandscape(Direction.Up, 0, new int[] {0, -2}),

                        new FigureLandscape(Direction.Up, 0, new int[] {-3, 0}),
                        new FigureLandscape(Direction.Up, 0, new int[] {0, -3}),
                    };
        public static FigureLandscape[] TAlternate = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Down, 0, new int[] {-2, 0, -2}),
                        new FigureLandscape(Direction.Right, -1, new int[] {0, -2}),
                        new FigureLandscape(Direction.Left, 0, new int[] {-2, 0}),

                        new FigureLandscape(Direction.Down, 0, new int[] {-3, 0, -3}),
                        new FigureLandscape(Direction.Right, -1, new int[] {0, -3}),
                        new FigureLandscape(Direction.Left, 0, new int[] {-3, 0}),
                    };
        public static FigureLandscape[] SAlternate = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Left, 0, new int[] {-2, 0}),
                        new FigureLandscape(Direction.Left, 0, new int[] {-3, 0}),

                        new FigureLandscape(Direction.Up, 0, new int[] {0, 0, 0}),
                    };
        public static FigureLandscape[] ZAlternate = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Left, 0, new int[] {0, 0}),
                        new FigureLandscape(Direction.Up, 0, new int[] {0, 0, 0}),

                        new FigureLandscape(Direction.Left, 0, new int[] {0, -2}),
                        new FigureLandscape(Direction.Left, 0, new int[] {0, -3}),

                    };
        public static FigureLandscape[] LAlternate = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Down, 1, new int[] {-3, 0}),
                        new FigureLandscape(Direction.Down, 1, new int[] {-4, 0}),
                        new FigureLandscape(Direction.Down, 1, new int[] {-5, 0}),
                    };
        public static FigureLandscape[] JAlternate = new FigureLandscape[]
                    {
                        new FigureLandscape(Direction.Down, -1, new int[] {0, -3}),
                        new FigureLandscape(Direction.Down, -1, new int[] {0, -4}),
                        new FigureLandscape(Direction.Down, -1, new int[] {0, -5}),
                    };

        #endregion
        public static FigureLandscape[] GetFigureLandscapes(Element element)
        {
            switch (element)
            {
                case Element.BLUE:
                    return ILandscape;

                case Element.YELLOW:
                    return OLandscape;

                case Element.CYAN:
                    return JLandscape;

                case Element.ORANGE:
                    return LLandscape;

                case Element.GREEN:
                    return SLandscape;

                case Element.PURPLE:
                    return TLandscape;

                case Element.RED:
                    return ZLandscape;
                default:
                    throw new ArgumentException();
            }
        }

        public static FigureLandscape[] GetAlternate(Element element)
        {
            switch (element)
            {
                case Element.BLUE:
                    return IAlternate;

                case Element.YELLOW:
                    return OAlternate;

                case Element.CYAN:
                    return JAlternate;

                case Element.ORANGE:
                    return LAlternate;

                case Element.GREEN:
                    return SAlternate;

                case Element.PURPLE:
                    return TAlternate;

                case Element.RED:
                    return ZAlternate;

                default:
                    throw new ArgumentException();
            }
        }
    }
}
