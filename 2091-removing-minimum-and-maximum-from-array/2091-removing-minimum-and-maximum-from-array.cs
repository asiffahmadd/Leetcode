public class Solution
{
    public int MinimumDeletions(int[] nums)
    {
        int n = nums.Length;

        int minIndex = 0;
        int maxIndex = 0;

        // Find min and max indices
        for (int i = 1; i < n; i++)
        {
            if (nums[i] < nums[minIndex])
                minIndex = i;

            if (nums[i] > nums[maxIndex])
                maxIndex = i;
        }

        int left = Math.Min(minIndex, maxIndex);
        int right = Math.Max(minIndex, maxIndex);

        // Option 1: Remove both from front
        int fromFront = right + 1;

        // Option 2: Remove both from back
        int fromBack = n - left;

        // Option 3: Remove one from front and one from back
        int fromBoth = (left + 1) + (n - right);

        return Math.Min(fromFront, Math.Min(fromBack, fromBoth));
    }
}