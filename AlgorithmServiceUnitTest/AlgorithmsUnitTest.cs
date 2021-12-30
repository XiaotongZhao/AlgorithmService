using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Algorithms.DynamicPlanning;
using Domain.Algorithms.Parallel;
using Domain.Algorithms.QuickSort.Service;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AlgorithmServiceUnitTest
{
    public class AlgorithmsUnitTest: IClassFixture<StartupFixture>
    {
        private readonly StartupFixture startupFixture;

        public AlgorithmsUnitTest(StartupFixture startupFixture)
        {
            this.startupFixture = startupFixture;
        }

      

        [Fact]
        public void TestQuickSortService()
        {
            using var scope = startupFixture.ServiceProvider.CreateScope();
            var quickSortService = scope.ServiceProvider.GetService<IQuickSortService>();
            var data = new int[] { 4, 2, 1, 5, 9, 6 };
            if (quickSortService != null)
            {
                var quickSortResult = quickSortService.QuickSort(data);
                var lastDataInQuickSortResult = quickSortResult.LastOrDefault();
                var stringBuilder = new StringBuilder();
                if (lastDataInQuickSortResult != null)
                    lastDataInQuickSortResult.ForEach(quickSortData => stringBuilder.Append(quickSortData.Value));
                Assert.True(stringBuilder.ToString() == "124569");
            }
        }

        [Fact]
        public void TestDynamicPlanningService()
        {
            using var scope = startupFixture.ServiceProvider.CreateScope();
            var dynamicPlanningService = scope.ServiceProvider.GetService<IDynamicPlanningService>();
            var x = "ABCBDAB";
            var y = "BDCABA";
            var res = dynamicPlanningService.GetLongestCommonSubsequence(x, y);
            Assert.True(res.ToString() == "ABCB");
        }


        [Fact]
        public async Task TestFib()
        {
            using var scope = startupFixture.ServiceProvider.CreateScope();
            var parallelService = scope.ServiceProvider.GetService<IParallelService>();
            var res = await parallelService.FibAsync(4);
            Assert.True(res == 5);

        }
    }
}