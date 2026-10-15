public class Solution {
    public int SumCounts(IList<int> nums) {
        int n = nums.Count;
        int result = 0;

        for (int i = 0; i < n; i++) {
            var seen = new HashSet<int>();
            for (int j = i; j < n; j++) {
                seen.Add(nums[j]);
                result += seen.Count * seen.Count;
            }
        }

        return result;
    }
}