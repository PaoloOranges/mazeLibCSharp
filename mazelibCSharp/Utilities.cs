namespace mazelibCSharp
{
    internal static class Utilities
    {
        public static int MazeRowToGridRow(int row, int cellHeight)
        {
            return cellHeight * row + 1;
        }

        public static int MazeColToGridCol(int col, int cellWidth)
        {
            return cellWidth * col + 1;
        }
    }
}
