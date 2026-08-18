public class Solution
{
    public int LargestInteger(int[] nums, int k)
    {
        int n = nums.Length;
        int[] count = new int[51];

        // Check every subarray of size k
        for (int i = 0; i <= n - k; i++)
        {
            bool[] seen = new bool[51];

            for (int j = i; j < i + k; j++)
            {
                int value = nums[j];

                // Count a number only once per subarray
                if (!seen[value])
                {
                    count[value]++;
                    seen[value] = true;
                }
            }
        }

        // Find largest number appearing in exactly one subarray
        for (int i = 50; i >= 0; i--)
        {
            if (count[i] == 1)
                return i;
        }

        return -1;
    }
}