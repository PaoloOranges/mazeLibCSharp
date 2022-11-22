// See https://aka.ms/new-console-template for more information
using mazelibCSharp.Generate;



MazeGenAlgo mazeGen = new MazeGenAlgo(3, 3, new AldousBroder());

var result = mazeGen.Generate();


for (int r = 0; r < result.GetLength(0); ++r)
{
    for (int c = 0; c < result.GetLength(1); ++c)
    {
        switch (result[r, c])
        {
            case mazelibCSharp.MazeCellType.Start:
                Console.Write("S");
                break;
            case mazelibCSharp.MazeCellType.End:
                Console.Write("E");
                break;
            case mazelibCSharp.MazeCellType.Path:
                Console.Write(" ");
                break;
            case mazelibCSharp.MazeCellType.Wall:
                Console.Write("#");
                break;
            default:
                Console.Write("?");
                break;

        }
    }
    Console.WriteLine();
}