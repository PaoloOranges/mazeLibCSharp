namespace mazelibCSharp
{
    public class Utilities
    {
        public static int CellWidth { get; } = 3;
        public static int CellHeight { get; } = 3;

        public static int MazeRowToGridRow(int row)
        {
            return CellHeight * row + 1;
        }

        public static int MazeColToGridCol(int col)
        {
            return CellWidth * col + 1;
        }
    }
}
