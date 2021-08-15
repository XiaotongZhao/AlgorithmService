using Domain.Algorithms.QuickSort;
using Domain.Algorithms.QuickSort.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Domain.Algorithms.DynamicPlanning;

namespace AlgorithmService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmsController : ControllerBase
    {
        private readonly IQuickSortService quickSortService;
        private readonly IDynamicPlanningService dynamicPlanningService;
        private readonly IConfiguration configuration;
        public AlgorithmsController(IConfiguration configuration, IQuickSortService quickSortService, IDynamicPlanningService dynamicPlanningService)
        {
            this.configuration = configuration;
            this.quickSortService = quickSortService;
            this.dynamicPlanningService = dynamicPlanningService;
        }

        [HttpPost]
        [Route("QuickSort")]
        public List<List<QuickSortData>> QuickSort(int[] datas)
        {
            return quickSortService.QuickSort(datas);
        }
        
        [HttpPost]
        [Route("DynamicPlanningFromTopToBottom")]
        public int DynamicPlanningUpToBottom(int[] prices, int n)
        {
            return dynamicPlanningService.DynamicPlanningFromTopToBottom(prices, n);
        }
        
        [HttpPost]
        [Route("DynamicPlanningFromBottomToTop")]
        public int DynamicPlanningFromBottomToTop(int[] prices, int n)
        {
            return dynamicPlanningService.DynamicPlanningFromBottomToTop(prices, n);
        }

        [HttpGet]
        [Route("Test")]
        public int Test(int i)
        {
            return i;
        }
    }
}
