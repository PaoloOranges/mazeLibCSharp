namespace mazelibCSharp.Solve
{
    public class DeadEndSolver : IMazeSolver
    {
        public List<CellCoordinate> Solve(MazeCellType[,] mazeGrid)
        {
            MazeCellType[,] mazeGridCopy = (MazeCellType[,])mazeGrid.Clone();

            List<CellCoordinate> result = new List<CellCoordinate>();

            int rowCount = mazeGrid.GetLength(0);
            int colCount = mazeGrid.GetLength(1);

            List<CellCoordinate> deadEnds = new List<CellCoordinate>();
            for (int r = 0; r < rowCount; ++r)
            {
                for(int c = 0; c < colCount; ++c)
                {
                    if (mazeGridCopy[r, c] == MazeCellType.Path && IsDeadEnd(mazeGridCopy, r, c))
                    {
                        deadEnds.Add(new CellCoordinate(r, c));
                    }
                }
            }

            foreach (CellCoordinate deadEnd in deadEnds)
            {
                int currentRow = deadEnd.row;
                int currentCol = deadEnd.col;
                var neighbourPaths = GetPathsAround(mazeGrid, deadEnd.row, deadEnd.col);

                while (neighbourPaths.Count == 1) // not a junction
                {
                    mazeGrid[currentRow, currentCol] = MazeCellType.Wall;

                    currentRow = neighbourPaths[0].row;
                    currentCol = neighbourPaths[0].col;

                    neighbourPaths = GetPathsAround(mazeGrid, currentRow, currentCol);
                }

            }

            //for (int r = 0; r < rowCount; ++r)
            //{
            //    for (int c = 0; c < colCount; ++c)
            //    {
            //        if (mazeGridCopy[r, c] == MazeCellType.Path && IsDeadEnd(mazeGridCopy, r, c))
            //        {
            //            deadEnds.Add(new CellCoordinate(r, c));
            //        }
            //    }
            //}

            return result;
        }

        private bool IsDeadEnd(MazeCellType[,] mazeGrid, int row, int col)
        {
            return GetPathsAround(mazeGrid, row, col).Count == 1;
        }

        private bool IsRowAndColumnValid(int row, int col, int height, int width)
        {
            return row >= 0 && row < height && col >= 0 && col < width;
        }

        private List<CellCoordinate> GetPathsAround(MazeCellType[,] mazeGrid, int row, int col)
        {
            List<CellCoordinate> result = new List<CellCoordinate>();

            int[] rShift = { -1, 0, 1, 0 };
            int[] cShift = { 0, 1, 0, -1 };

            const int shiftLength = 4;

            for (int i = 0; i < shiftLength; ++i)
            {
                int neighbourRow = row + rShift[i];
                int neighbourCol = col + cShift[i];

                if (IsRowAndColumnValid(neighbourRow, neighbourCol, mazeGrid.GetLength(0), mazeGrid.GetLength(1)))
                {
                    var cellType = mazeGrid[neighbourRow, neighbourCol];
                    if (cellType == MazeCellType.Path || cellType == MazeCellType.Start || cellType == MazeCellType.End)
                    {
                        result.Add(new CellCoordinate(neighbourRow, neighbourCol));
                    }
                }
            }

            return result;
        }
               
    }
}
