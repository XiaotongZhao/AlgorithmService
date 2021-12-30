using System.Threading.Tasks;

namespace Domain.Algorithms.Parallel
{
    public interface IParallelService
    {
        int FibAsync(int index);
        int Fib(int index);
    }
}