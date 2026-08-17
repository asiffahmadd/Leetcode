public class Solution
{
    public int StoneGameV(int[] stoneValue)
    {
        int n = stoneValue.Length;

        if (n <= 1)
            return 0;

        // Prefix Sum
        int[] prefix = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            prefix[i + 1] = prefix[i] + stoneValue[i];
        }

        // dp[l, r] = maximum score for subarray l..r
        int[,] dp = new int[n, n];

        // Length of subarray
        for (int len = 2; len <= n; len++)
        {
            for (int l = 0; l + len <= n; l++)
            {
                int r = l + len - 1;

                // Try every split
                for (int k = l; k < r; k++)
                {
                    int leftSum = prefix[k + 1] - prefix[l];
                    int rightSum = prefix[r + 1] - prefix[k + 1];

                    if (leftSum < rightSum)
                    {
                        dp[l, r] = Math.Max(
                            dp[l, r],
                            leftSum + dp[l, k]
                        );
                    }
                    else if (leftSum > rightSum)
                    {
                        dp[l, r] = Math.Max(
                            dp[l, r],
                            rightSum + dp[k + 1, r]
                        );
                    }
                    else
                    {
                        dp[l, r] = Math.Max(
                            dp[l, r],
                            Math.Max(
                                leftSum + dp[l, k],
                                rightSum + dp[k + 1, r]
                            )
                        );
                    }
                }
            }
        }

        return dp[0, n - 1];
    }
}