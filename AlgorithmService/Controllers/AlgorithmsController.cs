using Domain.Algorithms.QuickSort;
using Domain.Algorithms.QuickSort.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Dapr.Client;
using Domain.Algorithms.DynamicPlanning;
using Dapr;
using Microsoft.Extensions.Logging;

namespace AlgorithmService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmsController : ControllerBase
    {
        private readonly ILogger<AlgorithmsController> logger;

        private readonly DaprClient daprClient;
        private readonly IConfiguration configuration;
        private readonly IQuickSortService quickSortService;
        private readonly IDynamicPlanningService dynamicPlanningService;
        public AlgorithmsController(ILogger<AlgorithmsController> logger, IConfiguration configuration, IQuickSortService quickSortService, IDynamicPlanningService dynamicPlanningService, DaprClient daprClient)
        {
            this.logger = logger;
            this.daprClient = daprClient;
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

        [Topic("pubsub", "speedingviolations")]
        [Route("SubReciveData")]
        [HttpPost]
        public string SubReciveData(SendMessage message)
        {
            this.logger.LogInformation(message.Message);
            return message.Message;
        }
    }

    public class SendMessage
    {
        public string Message {get;set;}    
    }
}
