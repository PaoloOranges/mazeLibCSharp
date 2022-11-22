namespace mazelibCSharp.Generate
{
    public interface IMazeGeneratorAlgorithm
    {
        public MazeCellType[,] Generate(int height, int width);
    }
}
