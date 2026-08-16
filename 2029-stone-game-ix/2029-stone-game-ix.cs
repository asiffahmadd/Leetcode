public class Solution {
    public bool StoneGameIX(int[] stones) {
        int c0 = 0, c1 = 0, c2 = 0;
        foreach (int s in stones) {
            int r = s % 3;
            if (r == 0) c0++;
            else if (r == 1) c1++;
            else c2++;
        }
        
        if (c0 % 2 == 0) {
            return c1 > 0 && c2 > 0;
        } else {
            return Math.Abs(c1 - c2) > 2;
        }
    }
}