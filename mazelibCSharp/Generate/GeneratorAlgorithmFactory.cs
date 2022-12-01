

namespace mazelibCSharp.Generate
{
    internal static class GeneratorAlgorithmFactory
    {
        static internal IMazeGenerator GetAldousBorderGenerator()
        {
            return new AldousBroder();
        }
    }
}
