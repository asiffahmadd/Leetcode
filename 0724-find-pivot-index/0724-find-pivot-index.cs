public class Solution
{
    public int PivotIndex(int[] nums)
    {
        int n = nums.Length;

        int suml = 0;
        int sumr = 0;

        for (int i = 0; i < n; i++)
        {
            sumr += nums[i];
        }

        for (int i = 0; i < n; i++)
        {
            sumr -= nums[i];
            if (suml == sumr)
            {
                return i;
            }
            suml += nums[i];
        }

        return -1;
    }
}