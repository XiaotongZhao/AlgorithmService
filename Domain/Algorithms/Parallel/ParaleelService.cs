using System.Threading.Tasks;

namespace Domain.Algorithms.Parallel
{
    public class ParaleelService : IParallelService
    {
        public async Task<int> FibAsync(int index)
        {
            if (index == 0 || index == 1)
                return 1;
            else
            {
                var left = await FibAsync(index - 1);
                var right = FibAsync(index - 2);
                var res = left + (await right);
                return res;
            }
        }
    }
}