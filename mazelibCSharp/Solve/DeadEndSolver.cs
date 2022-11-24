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

            return result;
        }

        private bool IsDeadEnd(MazeCellType[,] mazeGrid, int row, int col)
        {
            int[] rShift = { -1, 0, 1, 0 };
            int[] cShift = { 0, 1, 0, -1 };

            const int shiftLength = 4;

            int passagesCount = 0;
            for(int i = 0; i < shiftLength; ++i)
            {
                int neighbourRow = row + rShift[i];
                int neighbourCol = col + cShift[i];

                if (neighbourRow >= 0 && neighbourRow < mazeGrid.GetLength(0) && neighbourCol >= 0 && neighbourCol < mazeGrid.GetLength(1))
                {
                    if (mazeGrid[neighbourRow, neighbourCol] == MazeCellType.Path)
                    {
                        passagesCount++;
                    }
                }
            }

            return passagesCount == 1;
        }
    }
}
