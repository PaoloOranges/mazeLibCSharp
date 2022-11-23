using System.Diagnostics;

namespace mazelibCSharp.Generate
{
    public class MazeGenAlgo
    {
        private int _height, _width;
        private IMazeGenerator _algorithm;

        public MazeCellType[,] Maze { get; set; }

        public MazeGenAlgo(int h, int w, IMazeGenerator algorithm)
        {
            Debug.Assert(w >= 3 && h >= 3, "Mazes cannot be smaller than 3x3.");
            _height = h;
            _width = w;

            _algorithm = algorithm;

        }

        /// <summary>
        /// Generate a maze. 
        /// </summary>
        /// 
        /// <returns>
        /// Returns a 3xH X 3xW matrix.
        /// </returns>
        public MazeCellType[,] Generate()
        {
            Maze = _algorithm.Generate(_height, _width);
            return Maze;
        }

        public MazeCellType[,] GenerateEntranceAndExit()
        {
            Random rnd = new Random();
            int side = rnd.Next(4); // 0: North, 1: East, 2: South, 3: West

            switch(side)
            {
                case 0:
                    {
                        int startCol = rnd.Next(_width);
                        int endCol = rnd.Next(_width);

                        Maze[0, 3 * startCol + 1] = MazeCellType.Start;
                        Maze[Maze.GetLength(0) - 1, 3 * endCol + 1] = MazeCellType.End;
                    }
                    break;
                case 1:
                    {
                        int startRow = rnd.Next(_height);
                        int endRow = rnd.Next(_height);

                        Maze[3 * endRow + 1, Maze.GetLength(1) - 1] = MazeCellType.Start;
                        Maze[3 * startRow + 1, 0] = MazeCellType.End;
                    }
                    break;
                case 2:
                    {
                        int startCol = rnd.Next(_width);
                        int endCol = rnd.Next(_width);

                        Maze[Maze.GetLength(0) - 1, 3 * endCol + 1] = MazeCellType.Start;
                        Maze[0, 3 * startCol + 1] = MazeCellType.End;
                    }
                    break;
                case 3:
                    {
                        int startRow = rnd.Next(_height);
                        int endRow = rnd.Next(_height);

                        Maze[3 * startRow + 1, 0] = MazeCellType.Start;
                        Maze[3 * endRow + 1, Maze.GetLength(1) - 1] = MazeCellType.End;
                    }
                    break;
                default:                   
                    Debug.Assert(false, "Wrong side!");
                    break;
            }

            return Maze;
        }

    }
}
