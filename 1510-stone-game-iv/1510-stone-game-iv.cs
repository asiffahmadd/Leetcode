public class Solution {
    public bool WinnerSquareGame(int n) {
        bool[] dp = new bool[n + 1];

        for (int i = 1; i <= n; i++) {
            for (int k = 1; k * k <= i; k++) {
                // If removing k*k stones leaves the opponent with a losing position, 
                // the current player can guarantee a win.
                if (!dp[i - k * k]) {
                    dp[i] = true;
                    break; // No need to check further square choices for this 'i'
                }
            }
        }

        return dp[n];
    }
}