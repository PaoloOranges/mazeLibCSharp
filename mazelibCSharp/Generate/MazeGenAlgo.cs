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

            Maze = new MazeCellType[0, 0];
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

            int startRow = 0;
            int startCol = 0;
            int endRow = 0;
            int endCol = 0;

            switch(side)
            {
                case 0:
                    {
                        startRow = 0;
                        endRow = Maze.GetLength(0) - 1;
                        startCol = Utilities.MazeColToGridCol(rnd.Next(_width));
                        endCol = Utilities.MazeColToGridCol(rnd.Next(_width));
                    }
                    break;
                case 1:
                    {
                        startRow = Utilities.MazeRowToGridRow(rnd.Next(_height));
                        endRow = Utilities.MazeRowToGridRow(rnd.Next(_height));                                                
                        startCol = Maze.GetLength(1) - 1;
                        endCol = 0;
                    }
                    break;
                case 2:
                    {
                        startRow = Maze.GetLength(0) - 1;
                        endRow = 0;
                        startCol = Utilities.MazeColToGridCol(rnd.Next(_width));
                        endCol = Utilities.MazeColToGridCol(rnd.Next(_width));
                    }
                    break;
                case 3:
                    {
                        startRow = Utilities.MazeRowToGridRow(rnd.Next(_height));
                        endRow = Utilities.MazeRowToGridRow(rnd.Next(_height));
                        startCol = 0;
                        endCol = Maze.GetLength(1) - 1;

                        Maze[3 * startRow + 1, 0] = MazeCellType.Start;
                        Maze[3 * endRow + 1, Maze.GetLength(1) - 1] = MazeCellType.End;
                    }
                    break;
                default:                   
                    Debug.Assert(false, "Wrong side!");
                    break;
            }

            Maze[startRow, startCol] = MazeCellType.Start;
            Maze[endRow, endCol] = MazeCellType.End;

            return Maze;
        }

    }
}
