public class Solution
{
    public int MissingInteger(int[] nums)
    {
        // Sum of the longest sequential prefix
        int sum = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1] + 1)
            {
                sum += nums[i];
            }
            else
            {
                break;
            }
        }

        // Find the smallest missing integer >= sum
        int x = sum;

        while (true)
        {
            bool found = false;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == x)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                return x;
            }

            x++;
        }
    }
}