

namespace mazelibCSharp.Generate
{
    public static class GeneratorAlgorithmFactory
    {
        static public IMazeGenerator GetAldousBorderGenerator()
        {
            return new AldousBroder();
        }
    }
}
