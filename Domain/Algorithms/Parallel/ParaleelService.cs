using System.Threading.Tasks;

namespace Domain.Algorithms.Parallel
{
    public class ParaleelService : IParallelService
    {
        private int fib(int index)
        {
            var res = new int[index + 1];
            for (var i = 0; i <= index; i++)
            {
                if (i <= 1)
                    res[i] = 1;
                else
                    res[i] = res[i - 1] + res[i - 2];
            }
            return res[index];
        }

        public async Task<int> FibAsync(int index)
        {
            if (index <= 1)
            {
                return 1;
            }
            else
            {
                var left = Task.Run(() => fib(index - 1));
                var right = Task.Run(() => fib(index - 2));
                var res = await left + await right;
                return res;
            }
        }

        public int Fib(int index)
        {
            var res = fib(index);
            return res;
        }
    }
}