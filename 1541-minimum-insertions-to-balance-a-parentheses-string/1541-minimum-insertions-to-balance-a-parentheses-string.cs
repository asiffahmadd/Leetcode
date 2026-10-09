public class Solution {
    public int MinInsertions(string s) {
        int open = 0;      // abhi tak unmatched '(' ki count
        int insertions = 0;
        int i = 0;

        while (i < s.Length) {
            if (s[i] == '(') {
                open++;
                i++;
            } else {
                // ')' mila, ye pair ka pehla hissa hai
                if (i + 1 < s.Length && s[i + 1] == ')') {
                    i += 2;            // dono ')' ek saath consume
                } else {
                    insertions++;      // dusra ')' missing, add karna padega
                    i++;
                }

                if (open > 0) {
                    open--;            // ek '(' match ho gaya
                } else {
                    insertions++;      // match karne ko '(' nahi tha, add karna padega
                }
            }
        }

        // bache hue har '(' ko '))' chahiye
        insertions += open * 2;
        return insertions;
    }
}