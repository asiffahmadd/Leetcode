public class Solution
{
    public int MaxPalindromes(string s, int k)
    {
        int n = s.Length;

        // pal[i, j] = true if s[i..j] is a palindrome
        bool[,] pal = new bool[n, n];

        for (int len = 1; len <= n; len++)
        {
            for (int i = 0; i + len - 1 < n; i++)
            {
                int j = i + len - 1;

                if (s[i] == s[j] && (len <= 2 || pal[i + 1, j - 1]))
                {
                    pal[i, j] = true;
                }
            }
        }

        // dp[i] = maximum number of valid palindromes
        // using the first i characters
        int[] dp = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            // Don't select a palindrome ending at i - 1
            dp[i] = dp[i - 1];

            // Try every palindrome ending at i - 1
            for (int start = 0; start <= i - k; start++)
            {
                if (pal[start, i - 1])
                {
                    dp[i] = Math.Max(dp[i], dp[start] + 1);
                }
            }
        }

        return dp[n];
    }
}