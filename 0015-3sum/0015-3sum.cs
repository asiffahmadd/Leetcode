public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        
        IList<IList<int>> newList = new List<IList<int>>();
        Array.Sort(nums);
        for(int i = 0; i< nums.Length - 2 && nums[i] <= 0; i++)
        {
            if(i > 0 && nums[i] == nums[i-1])
            {
                continue;
            }
            int left = i + 1;
            int right = nums.Length -1;
            while(left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                if(sum < 0)
                {
                    left++;
                }
                else if(sum > 0)
                {
                    right--;
                }
                else
                {
                    IList<int> list = new List<int>();
                    list.Add(nums[i]);
                    list.Add(nums[left]);
                    list.Add(nums[right]);
                    newList.Add(list);
                    left++;
                    right--;

                    while(left < right && nums[left] == nums[left-1])
                    {
                        left++;
                    }
                    while(left < right && nums[right] == nums[right+1])
                    {
                        right--;
                    }
                }
            }
        }
        
        return newList;
    }
}