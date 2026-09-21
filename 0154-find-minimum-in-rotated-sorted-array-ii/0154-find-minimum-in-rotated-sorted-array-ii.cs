public class Solution
{
    public int FindMin(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;

        while (l < r)
        {
            int mid = l + (r - l) / 2;

            if (nums[mid] < nums[r])
            {
                // Minimum left side me bhi ho sakta hai
                // mid khud bhi minimum ho sakta hai
                r = mid;
            }
            else if (nums[mid] > nums[r])
            {
                // Minimum definitely right side me hai
                l = mid + 1;
            }
            else
            {
                // nums[mid] == nums[r]
                // Duplicate ki wajah se decide nahi kar sakte
                r--;
            }
        }

        return nums[l];
    }
}