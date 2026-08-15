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

        // Entire array has non-zero XOR
        if (xor != 0)
            return nums.Length;

        // Total XOR is zero, but we can remove one non-zero element
        if (hasNonZero)
            return nums.Length - 1;

        // All elements are zero
        return 0;
    }
}