public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int s =m+n;
        int k=0;
        for(int i = m ;i<s;i++)
        {
            nums1[i] = nums2[k++];
        }
       // Array.Sort(nums1);
       for (int i = 0; i < s - 1; i++)
{
    for (int j = i + 1; j < s; j++)
    {
        if (nums1[i] > nums1[j])
        {
            int temp = nums1[i];
            nums1[i] = nums1[j];
            nums1[j] = temp;
        }
    }
}
    }
}