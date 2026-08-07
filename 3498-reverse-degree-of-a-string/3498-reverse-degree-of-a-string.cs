public class Solution {
    public int ReverseDegree(string s) {
        

        int sum = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int reverseValue = 'z' - s[i] + 1;
            sum += reverseValue * (i + 1);
        }

        return sum;
    }
}