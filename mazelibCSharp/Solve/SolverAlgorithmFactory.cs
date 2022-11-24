namespace mazelibCSharp.Solve
{
    public static class SolverAlgorithmFactory
    {
        public static IMazeSolver GetDeadEndSolver()
        {
            return new DeadEndSolver();
        }
    }
}
