using Domain.Algorithms.QuickSort;
using Domain.Algorithms.QuickSort.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AlgorithmService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmsController : ControllerBase
    {
        private readonly IQuickSortService quickSortService;
        private readonly IConfiguration configuration;
        public AlgorithmsController(IConfiguration configuration, IQuickSortService quickSortService)
        {
            this.configuration = configuration;
            this.quickSortService = quickSortService;
        }

        [HttpPost]
        [Route("QuickSort")]
        public List<List<QuickSortData>> QuickSort(int[] datas)
        {
            return quickSortService.QuickSort(datas);
        }
    }
}
