public class Solution
{
    public int MaxSubarrayLength(int[] nums, int k)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        int left = 0;
        int maxLength = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            if (!freq.ContainsKey(nums[right]))
            {
                freq[nums[right]] = 0;
            }

            freq[nums[right]]++;

            while (freq[nums[right]] > k)
            {
                freq[nums[left]]--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}