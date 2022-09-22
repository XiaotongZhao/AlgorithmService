using AlgorithmService.Domain.Algorithms.DynamicPlanning;
using AlgorithmService.Domain.Algorithms.Parallel;
using AlgorithmService.Domain.Algorithms.QuickSort.Service;

namespace AlgorithmService.UnitTest;

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
    public void TestFibAsync()
    {
        using var scope = startupFixture.ServiceProvider.CreateScope();
        var parallelService = scope.ServiceProvider.GetService<IParallelService>();
        var res = parallelService.FibAsync(100);
        //Assert.True(res == 5);
    }
    
    [Fact]
    public void TestFib()
    {
        using var scope = startupFixture.ServiceProvider.CreateScope();
        var parallelService = scope.ServiceProvider.GetService<IParallelService>();
        var res = parallelService.Fib(100);
        //Assert.True(res == 5);
    }
}
