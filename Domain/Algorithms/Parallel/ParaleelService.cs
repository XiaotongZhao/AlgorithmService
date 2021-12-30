using System.Threading.Tasks;

namespace Domain.Algorithms.Parallel
{
    public class ParaleelService : IParallelService
    {
        public int FibAsync(int index)
        {
            if (index <= 1)
            {
                return 1;
            }
            else
            {
                var left = Task.Run(() => FibAsync(index - 1));
                var right = FibAsync(index - 2);
                var res = left.Result + right;
                return res;
            }
        }

        public int Fib(int index)
        {
            if (index == 0 || index == 1)
                return 1;
            else
                return Fib(index - 1) + Fib(index - 2);
        }
    }
}