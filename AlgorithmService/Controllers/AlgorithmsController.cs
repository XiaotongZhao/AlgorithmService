using Microsoft.AspNetCore.Mvc;
using AlgorithmService.Domain.Algorithms.DynamicPlanning;
using AlgorithmService.Domain.Algorithms.QuickSort;
using AlgorithmService.Domain.Algorithms.QuickSort.Service;
using AlgorithmService.Domain.Tree.RedBlackTree.Model;
using AlgorithmService.Domain.Tree.RedBlackTree.Service;
using AlgorithmService.RedBlackTreeViewModel;

namespace AlgorithmService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlgorithmsController : ControllerBase
{
    private readonly IQuickSortService quickSortService;
    private readonly IRedBlackTreeService redBlackTreeService;
    private readonly IDynamicPlanningService dynamicPlanningService;
    public AlgorithmsController(IQuickSortService quickSortService,
        IRedBlackTreeService redBlackTreeService,
        IDynamicPlanningService dynamicPlanningService)
    {
        this.quickSortService = quickSortService;
        this.redBlackTreeService = redBlackTreeService;
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

    [HttpPost]
    [Route("CreateRedBlackTree")]
    public RedBlackTreeModel CreateRedBlackTree(int[] keys)
    {
        var tree = redBlackTreeService.CreateRedBlackTree(keys);
        var root = tree.GetRoot();
        var redBlackTree = RedBlackTree.ConvertBlackRedTreeToViewModel(root);
        redBlackTree.Links.ForEach(link => 
        {
            link.Source = redBlackTree.DicKeyAndId[link.Source];
            link.Target = redBlackTree.DicKeyAndId[link.Target];
        });
        return redBlackTree;
    }
}

