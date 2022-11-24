using System.Diagnostics;

namespace mazelibCSharp.Generate
{
    /// <summary>
    ///     1. Choose a random cell.
    ///     2. Choose a random neighbor of the current cell and visit it.If the neighbor has not yet been visited, add the traveled edge to the spanning tree.
    ///     3. Repeat step 2 until all cells have been visited.
    /// </summary>
    internal class AldousBroder : IMazeGenerator
    {
        /// <summary>
        /// highest-level method that implements the maze-generating algorithm
        /// <returns> array returned matrix </returns>
        /// </summary>
        public MazeCellType[,] Generate(int height, int width)
        {
            // each maze cell will be 3x3 
            int mazeHeight = Utilities.CellHeight * height;
            int mazeWidth = Utilities.CellWidth * width;
            
            MazeCellType[,] grid = new MazeCellType[mazeHeight, mazeWidth];

            for (int i = 0; i < mazeHeight; ++i)
            {
                for (int j = 0; j < mazeWidth; ++j)
                {
                    // initialize border elements with Walls
                    MazeCellType cellType = (i != 0 && i != mazeHeight-1 && j != 0 && j != mazeWidth-1) ? MazeCellType.Uninitialized : MazeCellType.Wall;

                    grid[i, j] = cellType;
                }
            }            

            Random rnd = new Random();

            // take random value in the original size 
            int currentRow = rnd.Next(0, height);
            int currentCol = rnd.Next(0, width);

            int totalMazeSize = height * width;

            grid[Utilities.MazeRowToGridRow(currentRow), Utilities.MazeColToGridCol(currentCol)] = MazeCellType.Path;

            int numVisited = 1;

            while(numVisited < totalMazeSize)
            {
                var neighbours = GetNeighboursCoordinateList(currentRow, currentCol, height, width);

                int row = Utilities.MazeRowToGridRow(currentRow);
                int col = Utilities.MazeColToGridCol(currentCol);

                foreach (var neighbour in neighbours)
                {
                    int nR = Utilities.MazeRowToGridRow(neighbour.row);
                    int nC = Utilities.MazeColToGridCol(neighbour.col);

                    currentRow = neighbour.row;
                    currentCol = neighbour.col;

                    if (grid[nR, nC] == MazeCellType.Uninitialized)
                    {
                        grid[nR, nC] = MazeCellType.Path;
                        numVisited++;

                        // make path from current to current neighbour 
                        int rowShift = nR - row;
                        int colShift = nC - col;

                        Debug.Assert(rowShift != 0 || colShift != 0 && rowShift != colShift, "diagonal shift error");

                        int[] rowShifts = GetRangeFromZero(rowShift);
                        int[] colShifts = GetRangeFromZero(colShift);
                        foreach (int shift in rowShifts)
                        {
                            grid[row + shift, col] = MazeCellType.Path;
                        }

                        foreach (int shift in colShifts)
                        {
                            grid[row, col + shift] = MazeCellType.Path;
                        }                        

                        break;
                    }
                }
            }

            // Finilize making all uninitialized cell to walls

            for (int i = 0; i < mazeHeight; ++i)
            {
                for (int j = 0; j < mazeWidth; ++j)
                {
                    // initialize border elements with Walls
                    MazeCellType cellType = (i != 0 && i != mazeHeight - 1 && j != 0 && j != mazeWidth - 1) ? MazeCellType.Uninitialized : MazeCellType.Wall;

                    grid[i, j] = (grid[i, j] == MazeCellType.Uninitialized) ? MazeCellType.Wall : grid[i, j];
                }
            }

            return grid;
        }

        private List<CellCoordinate> GetNeighboursCoordinateList(int row, int col, int height, int width)
        {
            List<CellCoordinate> neighbours = new List<CellCoordinate>();

            int[] rowShift = { -1, 0, 1, 0};
            int[] colShift = { 0, -1, 0, 1 };

            for(int i = 0; i < 4; ++i)
            {
                int neighbourRow = row + rowShift[i];
                int neighbourCol = col + colShift[i];

                if(neighbourRow >= 0 && neighbourRow < height && neighbourCol >= 0 && neighbourCol < width)
                {
                    neighbours.Add(new CellCoordinate(neighbourRow, neighbourCol));
                }                
            }

            return neighbours;
        }

        private int[] GetRangeFromZero(int to)
        {
            if(to >= 0)
            {
                return Enumerable.Range(0, to).ToArray();
            }

            int count = -to;
            return Enumerable.Range(to, count).ToArray();
        }
    }
}
