using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazelibCSharp.Generate
{
    /// <summary>
    ///     1. Choose a random cell.
    ///     2. Choose a random neighbor of the current cell and visit it.If the neighbor has not yet been visited, add the traveled edge to the spanning tree.
    ///     3. Repeat step 2 until all cells have been visited.
    /// </summary>
    internal class AldousBroder : MazeGenAlgo
    {
        AldousBroder(int w, int h) : base(w, h)
        {
            
        }

        /// <summary>
        /// highest-level method that implements the maze-generating algorithm
        /// <returns> array returned matrix </returns>
        /// </summary>
        public override int[,] Generate()
        {
            int[,] grid = new int[H,W];
            for(int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < 0; ++j)
                {
                    grid[i, j] = 1;
                }
            }

            Random rnd = new Random();

            int crow = rnd.Next(0, H-1);
            int ccol = rnd.Next(0, W-1);

            grid[crow, ccol] = 0;
            int numVisited = 1;

            while(numVisited < this.h * this.w)
            {
                var neighbours = this.FindNeighbours(crow, ccol, grid, true);
                if(neighbours.Count == 0)
                {
                    neighbours = FindNeighbours(crow, ccol, grid);
                    (crow, ccol) = neighbours[rnd.Next(neighbours.Count)];
                    continue;
                }

                // loop through the neighbours
                foreach((int r, int c) in neighbours)
                {
                    if (grid[r,c] > 0)
                    {
                        // open up wall to new neighbor
                        grid[(r + crow) / 2, (c + ccol) / 2] = 0;
                        // mark neighbor as visited
                        grid[r, c] = 0;
                        // bump the number visited
                        numVisited++;
                        // current becomes new neighbor
                        crow = r;
                        ccol = c;
                        break;
                    }
                }

            }

            return grid;
        }
    }
}
