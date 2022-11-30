using System.Collections.Generic;

namespace mazelibCSharp.Solve
{
    public class MazeSolverAlgo
    {
        private IMazeSolver _mazeSolver;
        public MazeSolverAlgo(IMazeSolver mazeSolver)
        {
            _mazeSolver = mazeSolver;
        }

        public List<CellCoordinate> Solve(MazeCellType[,] mazeGrid)
        {
            return _mazeSolver.Solve(mazeGrid);
        }
    }
}