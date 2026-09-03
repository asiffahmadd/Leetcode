public class Solution
{
    public bool UniformArray(int[] nums1)
    {
        int min = nums1[0];
        bool allEven = true;

        foreach (int num in nums1)
        {
            if (num < min)
                min = num;

            if (num % 2 != 0)
                allEven = false;
        }

        return allEven || min % 2 != 0;
    }
}