namespace AlgorithmService.Domain.Algorithms.Parallel;

public interface IParallelService
{
    Task<int> FibAsync(int index);
    int Fib(int index);
    int[,] CalculateMatrix(int[,] matrixA, int[,] matrixB);
}
