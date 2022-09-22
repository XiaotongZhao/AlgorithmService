namespace AlgorithmService.Domain.Algorithms.DynamicPlanning;

public class DynamicPlanningService : IDynamicPlanningService
{
    public DynamicPlanningService()
    {
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

    public string GetLongestCommonSubsequence(string x, string y)
    {
        var stringBuilder = new StringBuilder();
        var graphic = CalculateLongestCommonSubsequence(x, y);
        var i = graphic.GetLength(0) - 1;
        var j = graphic.GetLength(1) - 1;
        while (i >= 0 && j >= 0)
        {
            if (graphic[i, j] == "↖")
            {
                stringBuilder.Append(x[i - 1]);
                --j;
                --i;
            }
            else if (graphic[i, j] == "↑")
                --i;
            else
                --j;
        }

        return stringBuilder.ToString();
    }

    private string[,] CalculateLongestCommonSubsequence(string x, string y)
    {
        x = $"0{x}";
        y = $"0{y}";
        var row = x.Length;
        var line = y.Length;
        var graphic = new string[row, line];
        var length = new int[row, line];
        for (var i = 0; i < row; i++)
            length[i, 0] = 0;
        for (var j = 0; j < line; j++)
            length[0, j] = 0;
        for (var i = 1; i < row; i++)
        {
            for (var j = 1; j < line; j++)
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

        return graphic;
    }
}
