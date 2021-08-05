using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Algorithms.DynamicPlanning
{
    public interface IDynamicPlanningService
    {
        string GetLongestCommonSubsequence(string[] x, string[] y);
        int DynamicPlanningFromTopToBottom(int[] price, int n);
        int DynamicPlanningFromBottomToTop(int[] price, int n);

    }
}
