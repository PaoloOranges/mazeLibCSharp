
using System.Collections.Generic;

namespace mazelibCSharp.Solve
{
    public interface IMazeSolver
    {
        public List<CellCoordinate> Solve(MazeCellType[,] mazeGrid);
    }
}
