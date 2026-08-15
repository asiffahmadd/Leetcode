public class Solution
{
    public int LongestSubsequence(int[] nums)
    {
        int xor = 0;
        bool hasNonZero = false;

        foreach (int num in nums)
        {
            xor ^= num;

            if (num != 0)
                hasNonZero = true;
        }

        if (xor != 0)
            return nums.Length;

        if (hasNonZero)
            return nums.Length - 1;

        return 0;
    }
}