using System;
using Domain.Algorithms.DynamicPlanning;
using Domain.Algorithms.QuickSort.Service;
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
            
            ServiceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
        }
    }
}