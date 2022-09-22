namespace AlgorithmService.Domain.Algorithms.QuickSort.Service;

public interface IQuickSortService
{
    List<List<QuickSortData>> QuickSort(int[] datas);
}
