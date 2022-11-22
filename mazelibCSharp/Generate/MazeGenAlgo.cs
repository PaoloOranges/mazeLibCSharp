using System.Diagnostics;

namespace mazelibCSharp.Generate
{
    public class MazeGenAlgo
    {
        private int _height, _width;
        private IMazeGeneratorAlgorithm _algorithm;

        public MazeGenAlgo(int h, int w, IMazeGeneratorAlgorithm algorithm)
        {
            Debug.Assert(w >= 3 && h >= 3, "Mazes cannot be smaller than 3x3.");
            _height = h;
            _width = w;

            _algorithm = algorithm;

        }

        /// <summary>
        /// Generate a maze. 
        /// </summary>
        /// 
        /// <returns>
        /// Returns a 2H+1 X 2W+1 matrix.
        /// </returns>
        public MazeCellType[,] Generate()
        {
            return _algorithm.Generate(_height, _width);
        }

    }
}
