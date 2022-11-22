// See https://aka.ms/new-console-template for more information
using mazelibCSharp.Generate;



MazeGenAlgo mazeGen = new MazeGenAlgo(3, 3, new AldousBroder());

var result = mazeGen.Generate();

Console.WriteLine("Hello, World!");