using System.Diagnostics;

namespace mazelibCSharp.Generate
{
    internal abstract class MazeGenAlgo
    {
        protected int h, w;
        protected int H, W; 
        public MazeGenAlgo(int h, int w)
        {
            Debug.Assert(w >= 3 && h >= 3, "Mazes cannot be smaller than 3x3.");            
            this.h = h;
            this.w = w;
            this.H = (2 * h) + 1;
            this.W = (2 * w) + 1;

        }

        public abstract int[,] Generate();

        // Helper methods

        /// <summary>        
        /// Find all the grid neighbors of the current position; visited, or not.
        /// <param name="row"> row of the cell of interest </param>
        /// <param name="col"> column of the cell of interest </param>
        /// <param name="grid"> 2D maze grid</param>
        /// <param name="isWall"> Are we looking for neighbors that are walls, or open cells?</param>
        /// <returns>
        /// list: all neighboring cells that match our request
        /// </returns>
        /// </summary>
        protected List<(int, int)> FindNeighbours(int row, int col, int[,] grid, bool isWall = false)
        {
            List<(int, int)> neighbours = new List<(int, int)>();

            int isWallValue = isWall ? 1 : 0;

            if(row > 1 && grid[row - 2, col] == isWallValue)
            {
                neighbours.Add((row - 2, col));
            }
            if(row < H - 2 && grid[row + 2, col] == isWallValue)
            {
                neighbours.Add((row + 2, col));
            }
            if(col > 1 && grid[row, col - 2] == isWallValue)
            {
                neighbours.Add((row, col - 2));
            }
            if (col < W - 2 && grid[row, col + 2] == isWallValue)
            {
                neighbours.Add((row, col + 2));
            }

            // shuffle 
            Random rand = new Random();
            var shuffled = neighbours.OrderBy(_ => rand.Next()).ToList();

            return shuffled;
        }

    }
}
