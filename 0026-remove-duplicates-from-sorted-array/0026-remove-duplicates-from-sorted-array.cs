public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if (nums.Length == 0) return 0;

        int i = 0; // slow pointer - last unique element ka index

        for (int j = 1; j < nums.Length; j++) { // fast pointer
            if (nums[j] != nums[i]) {
                i++;
                nums[i] = nums[j];
            }
        }

        return i + 1; // total unique elements count
    }
}