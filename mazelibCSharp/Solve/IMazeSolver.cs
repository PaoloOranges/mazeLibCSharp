
namespace mazelibCSharp.Solve
{
    public interface IMazeSolver
    {
        public List<CellCoordinate> Solve(MazeCellType[,] mazeGrid, CellCoordinate start, CellCoordinate end);
    }
}
