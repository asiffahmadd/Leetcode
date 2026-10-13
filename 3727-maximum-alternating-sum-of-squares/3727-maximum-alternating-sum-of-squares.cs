public class Solution {
    public long MaxAlternatingSum(int[] nums) {
        int n = nums.Length;
        long[] sq = new long[n];

        for (int i = 0; i < n; i++) {
            sq[i] = (long)nums[i] * nums[i];
        }

        Array.Sort(sq);

        int minusCount = n / 2;     // chhote squares, inhe subtract karna hai
        long result = 0;

        for (int i = 0; i < n; i++) {
            if (i < minusCount) result -= sq[i];
            else result += sq[i];
        }

        return result;
    }
}