using System;

namespace Domain.Algorithms.DynamicPlanning
{
    public class DynamicPlanningService : IDynamicPlanningService
    {
        public DynamicPlanningService()
        {
        }

        public string[] GetLongestCommonSubsequence(int[,] backup, string[] x, int i, int j)
        {
            throw new NotImplementedException();
        }

        public int DynamicPlanningFromTopToBottom(int[] price, int n)
        {
            int[] r = new int[n + 1];
            return GetMaxProceedsTopToBottom(price, n, r);
        }

        public int DynamicPlanningFromBottomToTop(int[] price, int n)
        {
            var backUp = new int[n + 1];
            var res = GetMaxProceedsFromBottomToTop(price, n, backUp);
            return res;
        }

        private int GetMaxProceedsFromBottomToTop(int[] price, int n, int[] backUp)
        {
            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                result = 0;
                for (int j = 1; j <= i; j++)
                {
                    result = Math.Max(result, price[j] + backUp[i - j]);
                }

                backUp[i] = result;
            }

            return result;
        }

        private int GetMaxProceedsTopToBottom(int[] price, int n, int[] backUp)
        {
            if (backUp[n] > 0)
                return backUp[n];
            var result = 0;
            if (n == 0)
                result = 0;
            else
                for (var i = 1; i <= n; i++)
                    result = Math.Max(result, price[i] + GetMaxProceedsTopToBottom(price, n - i, backUp));
            backUp[n] = result;
            return result;
        }

        private (int[,] length, string[,] graphic) CalculateLongestCommonSubsequence(string[] x, string[] y)
        {
            var row = x.Length;
            var line = y.Length;
            string[,] graphic = new string[row, line];

            int[,] length = new int[row, line];
            for (int i = 0;
                i < row;
                i++)
                length[i, 0] = 0;
            for (int j = 0;
                j < line;
                j++)
                length[0, j] = 0;
            for (int i = 1;
                i < line;
                i++)
            {
                for (int j = 1; j < row; j++)
                {
                    if (x[i] == y[j])
                    {
                        length[i, j] = length[i - 1, j - 1] + 1;
                        graphic[i, j] = "↖";
                    }
                    else if (length[i - 1, j] >= length[i, j - 1])
                    {
                        length[i, j] = length[i - 1, j];
                        graphic[i, j] = "↑";
                    }
                    else
                    {
                        length[i, j] = length[i, j - 1];
                        graphic[i, j] = "←";
                    }
                }
            }

            return (length, graphic);
        }
    }
}