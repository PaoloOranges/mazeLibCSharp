namespace mazelibCSharp.Generate
{
    public interface IMazeGenerator
    {
        public MazeCellType[,] Generate(int height, int width);
    }
}
