using System.Threading.Tasks;

namespace Domain.Algorithms.Parallel
{
    public interface IParallelService
    {
        Task<int> FibAsync(int index);
    }
}