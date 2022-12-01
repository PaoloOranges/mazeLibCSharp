using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazelibCSharp.Generate
{
    public static class MazeGeneratorFactory
    {
        public static MazeGenAlgo CreateAldousBroderGenerator(int width, int height, int cellWidth, int cellHeight)
        {
            return new MazeGenAlgo(width, height, cellWidth, cellHeight, GeneratorAlgorithmFactory.GetAldousBorderGenerator());
        }
    }
}
