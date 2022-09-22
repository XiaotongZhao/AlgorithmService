using Microsoft.AspNetCore.Mvc;
using AlgorithmService.Domain.Algorithms.DynamicPlanning;
using AlgorithmService.Domain.Algorithms.QuickSort;
using AlgorithmService.Domain.Algorithms.QuickSort.Service;

namespace AlgorithmService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlgorithmsController : ControllerBase
{
    private readonly IQuickSortService quickSortService;
    private readonly IDynamicPlanningService dynamicPlanningService;
    public AlgorithmsController(IQuickSortService quickSortService, IDynamicPlanningService dynamicPlanningService)
    {
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
}

