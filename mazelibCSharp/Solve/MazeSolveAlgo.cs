//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace mazelibCSharp.Solve
//{
//    internal public abstract class MazeSolveAlgo
//    {

//        private int[,] grid;
//        private Cell start;
//        private Cell end;

//        /// <summary>
//        /// helper method to solve a init the solver before solving the maze
//        /// </summary>
//        /// <param name="grid">maze array</param>
//        /// <param name="start"></param>
//        /// <param name="end"></param>
//        /// <returns> List of cell for the final solution</returns>
//        // 
//        //         Args:
//        //             grid (np.array): maze array
//        //             start (tuple): position in maze to start from
//        //             end (tuple): position in maze to finish at
//        //         Returns:
//        //             list: final solutions
//        //         
//        public List<Cell> Solve(int[,] grid, Cell start, Cell end)
//        {
//            SolvePreprocessor(grid, start, end);
//            return this.DoSolve();
//        }

//        // ensure the maze mazes any sense before you solve it
//        // 
//        //         Args:
//        //             grid (np.array): maze array
//        //             start (tuple): position in maze to start from
//        //             end (tuple): position in maze to finish at
//        //         Returns: None
//        //         
//        public void SolvePreprocessor(int[,] grid, Cell start, Cell end)
//        {
//            this.grid = grid.copy();
//            this.start = start;
//            this.end = end;
//            // validating checks
//            Debug.Assert(grid != null, "Maze grid is not set.");
//            Debug.Assert(start.row >= 0 && start.row < grid.GetLength(0), "Entrance is outside the grid.");
//            Debug.Assert(start.col >= 0 && start.col < grid.GetLength(1), "Entrance is outside the grid.");
//            Debug.Assert(end.row >= 0 && end.col < grid.GetLength(0), "Entrance is outside the grid.");
//            Debug.Assert(end.row >= 0 && end.col < grid.GetLength(1), "Entrance is outside the grid.");
//        }

//        public abstract List<Cell> DoSolve();


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="posInterest">cell of interest</param>
//        /// <returns>list: all the unblocked neighbors to this cell</returns>
      
//        protected List<Cell> FindUnblockedNeighbours(Cell posInterest)
//        {
//            var ns = new List<Cell>();
//            if (posInterest.row > 1 && this.grid[posInterest.row - 1, posInterest.col] == 0 && this.grid[posInterest.row - 2, posInterest.col] == 0)
//            {
//                ns.Add(new Cell(posInterest.row - 2, posInterest.col));
//            }
//            if (posInterest.row < this.grid.GetLength(0) - 2 && this.grid[posInterest.row + 1, posInterest.col] == 0 && this.grid[posInterest.row + 2, posInterest.col] == 0)
//            {
//                ns.Add(new Cell(posInterest.row + 2, posInterest.col));
//            }
//            if (posInterest.col > 1 && !this.grid[posInterest.row, c - 1] && !this.grid[posInterest.row, c - 2])
//            {
//                ns.append((posInterest.row, c - 2));
//            }
//            if (c < this.grid.shape[1] - 2 && !this.grid[posInterest.row, c + 1] && !this.grid[posInterest.row, c + 2])
//            {
//                ns.append((posInterest.row, c + 2));
//            }
//            shuffle(ns);
//            return ns;
//        }

//        // Find the wall cell between to passage cells
//        // 
//        //         Args:
//        //             a (tuple): first cell
//        //             b (tuple): second cell
//        //         Returns:
//        //             tuple: cell half way between the first two
//        //         
//        public virtual object _midpoint(object a, object b)
//        {
//            return Tuple.Create((a[0] + b[0]) / 2, (a[1] + b[1]) / 2);
//        }

//        // Convolve a position tuple with a direction tuple to generate a new position.
//        // 
//        //         Args:
//        //             start (tuple): position cell to start at
//        //             direction (tuple): vector cell of direction to travel to
//        //         Returns:
//        //             tuple: end result of movement
//        //         
//        public virtual object _move(object start, object direction)
//        {
//            return tuple(map(sum, zip(start, direction)));
//        }

//        // Does the cell lay on the edge, rather inside of the maze grid?
//        // 
//        //         Args:
//        //             cell (tuple): some place in the grid
//        //         Returns:
//        //             bool: Is the cell on the edge of the maze?
//        //         
//        public virtual object _on_edge(object cell)
//        {
//            var _tup_1 = cell;
//            var r = _tup_1.Item1;
//            var c = _tup_1.Item2;
//            if (r == 0 || r == this.grid.shape[0] - 1)
//            {
//                return true;
//            }
//            if (c == 0 || c == this.grid.shape[1] - 1)
//            {
//                return true;
//            }
//            return false;
//        }

//        // You may need to find the cell directly inside of a start or end cell.
//        // 
//        //         Args:
//        //             cell (tuple): some place in the grid
//        //         Returns:
//        //             tuple: the new cell location, pushed from the edge
//        //         
//        public virtual object _push_edge(object cell)
//        {
//            var _tup_1 = cell;
//            var r = _tup_1.Item1;
//            var c = _tup_1.Item2;
//            if (r == 0)
//            {
//                return (1, c);
//            }
//            else if (r == this.grid.shape[0] - 1)
//            {
//                return (r - 1, c);
//            }
//            else if (c == 0)
//            {
//                return (r, 1);
//            }
//            else
//            {
//                return (r, c - 1);
//            }
//        }

//        // Is the current cell within one move of the desired cell?
//        //         Note, this might be one full more, or one half move.
//        // 
//        //         Args:
//        //             cell (tuple): position to start at
//        //             desire (tuple): position you want to be at
//        //         Returns:
//        //             bool: Are you within one movement of your goal?
//        //         
//        public virtual object _within_one(object cell, object desire)
//        {
//            if (!cell || !desire)
//            {
//                return false;
//            }
//            if (cell[0] == desire[0])
//            {
//                if (abs(cell[1] - desire[1]) < 2)
//                {
//                    return true;
//                }
//            }
//            else if (cell[1] == desire[1])
//            {
//                if (abs(cell[0] - desire[0]) < 2)
//                {
//                    return true;
//                }
//            }
//            return false;
//        }

//        // In the process of solving a maze, the algorithm might go down
//        //         the wrong corridor then backtrack. These extraneous steps need to be removed.
//        //         Also, clean up the end points.
//        // 
//        //         Args:
//        //             solution (list): raw maze solution
//        //         Returns:
//        //             list: cleaner, tightened up solution to the maze
//        //         
//        public virtual object _prune_solution(object solution)
//        {
//            var found = true;
//            var attempt = 0;
//            var max_attempt = solution.Count;
//            while (found && solution.Count > 2 && attempt < max_attempt)
//            {
//                found = false;
//                attempt += 1;
//                foreach (var i in Enumerable.Range(0, solution.Count - 1))
//                {
//                    var first = solution[i];
//                    if (solution[i + 1].Contains(first))
//                    {
//                        var first_i = i;
//                        var last_i = solution[i + 1].index(first) + i + 1;
//                        found = true;
//                        break;
//                    }
//                }
//                if (found)
//                {
//                    solution = solution[::first_i] + solution[last_i];
//                }
//            }
//            // solution does not include entrances
//            if (solution.Count > 1)
//            {
//                if (solution[0] == this.start)
//                {
//                    solution = solution[1];
//                }
//                if (solution[-1] == this.end)
//                {
//                    solution = solution[:: - 1];
//                }
//            }
//            return solution;
//        }

//        // prune all the duplicate cells from all solutions, and fix end points
//        // 
//        //         Args:
//        //             solutions (list): multiple raw solutions
//        //         Returns:
//        //             list: the above solutions, cleaned up
//        //         
//        public virtual object prune_solutions(object solutions)
//        {
//            return (from s in solutions
//                    select this._prune_solution(s)).ToList();
//        }
//    }
//}
