using System;

public class Solution {
    public int StoneGameII(int[] piles) {
        int n = piles.Length;
        int[] suffixSum = new int[n];
        
        // Step 1: Precalculate suffix sums
        suffixSum[n - 1] = piles[n - 1];
        for (int k = n - 2; k >= 0; k--) {
            suffixSum[k] = suffixSum[k + 1] + piles[k];
        }

        // Memoization table: memo[i, m] stores max stones obtainable from index i with parameter m
        int[,] memo = new int[n, n + 1];

        return GetMaxStones(0, 1, piles, suffixSum, memo);
    }

    private int GetMaxStones(int i, int m, int[] piles, int[] suffixSum, int[,] memo) {
        int n = piles.Length;

        // Base Case: If remaining piles can all be taken in one turn
        if (i + 2 * m >= n) {
            return suffixSum[i];
        }

        if (memo[i, m] != 0) {
            return memo[i, m];
        }

        int maxStones = 0;

        // Try taking X piles where 1 <= X <= 2 * M
        for (int x = 1; x <= 2 * m; x++) {
            int nextM = Math.Max(m, x);
            // Current player gets suffixSum[i] minus what opponent gets from (i + x)
            int currentStones = suffixSum[i] - GetMaxStones(i + x, nextM, piles, suffixSum, memo);
            maxStones = Math.Max(maxStones, currentStones);
        }

        memo[i, m] = maxStones;
        return maxStones;
    }
}