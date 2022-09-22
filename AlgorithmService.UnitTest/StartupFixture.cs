using AlgorithmService.Domain.Algorithms.DynamicPlanning;
using AlgorithmService.Domain.Algorithms.Parallel;
using AlgorithmService.Domain.Algorithms.QuickSort.Service;
using AlgorithmService.Domain.Tree.BinaryTree.Service;
using AlgorithmService.Domain.Tree.RedBlackTree.Service;

namespace AlgorithmService.UnitTest;

public class StartupFixture: IDisposable
{
    public IServiceProvider ServiceProvider { get; set; }
    public StartupFixture()
    {
        var services = new ServiceCollection();
        services.AddScoped<IQuickSortService, QuickSortService>();
        services.AddScoped<IDynamicPlanningService, DynamicPlanningService>();
        services.AddScoped<IBinaryTreeService, BinaryTreeService>();
        services.AddScoped<IRedBlackTreeService, RedBlackTreeService>();
        services.AddScoped<IParallelService, ParaleelService>();

        ServiceProvider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
    }
}
