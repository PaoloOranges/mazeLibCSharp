// See https://aka.ms/new-console-template for more information
using mazelibCSharp.Generate;
using mazelibCSharp.Solve;

MazeGenAlgo mazeGen = MazeGeneratorFactory.CreateAldousBroderGenerator(5, 5, 3, 3);
MazeSolverAlgo mazeSolver = new MazeSolverAlgo(SolverAlgorithmFactory.GetDeadEndSolver());


mazeGen.Generate();
var maze = mazeGen.GenerateEntranceAndExit();

var solutionPath = mazeSolver.Solve(maze);

char[,] outputRender = new char[maze.GetLength(0), maze.GetLength(1)];
for (int r = 0; r < maze.GetLength(0); ++r)
{
    for (int c = 0; c < maze.GetLength(1); ++c)
    {
        switch (maze[r, c])
        {
            case mazelibCSharp.MazeCellType.Start:
                outputRender[r, c] = 'S';                
                break;
            case mazelibCSharp.MazeCellType.End:
                outputRender[r, c] = 'E';
                break;
            case mazelibCSharp.MazeCellType.Path:
                outputRender[r, c] = ' ';
                break;
            case mazelibCSharp.MazeCellType.Wall:
                outputRender[r, c] = '#';
                break;
            default:
                outputRender[r, c] = '?';
                break;

        }
    }    
}

foreach(var cell in solutionPath)
{
    outputRender[cell.row, cell.col] = '+';
}

for (int r = 0; r < outputRender.GetLength(0); ++r)
{
    for (int c = 0; c < outputRender.GetLength(1); ++c)
    {
        Console.Write(outputRender[r, c]);
    }
    Console.WriteLine();
}
