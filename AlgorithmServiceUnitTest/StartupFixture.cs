using System;
using Domain.Algorithms.DynamicPlanning;
using Domain.Algorithms.QuickSort.Service;
using Domain.Tree.BinaryTree.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmServiceUnitTest
{
    public class StartupFixture: IDisposable
    {
        public IServiceProvider ServiceProvider { get; set; }
        public StartupFixture()
        {
            var services = new ServiceCollection();
            services.AddScoped<IQuickSortService, QuickSortService>();
            services.AddScoped<IDynamicPlanningService, DynamicPlanningService>();
            services.AddScoped<IBinaryTreeService, BinaryTreeService>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
        }
    }
}