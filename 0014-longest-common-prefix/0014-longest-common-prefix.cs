public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (strs.Length == 0) return "";

        string pre = strs[0]; // start with first string as prefix

        for (int i = 1; i < strs.Length; i++) {
            // reduce 'pre' until it matches the start of strs[i]
            while (strs[i].IndexOf(pre) != 0) {
                pre = pre.Substring(0, pre.Length - 1);
                if (pre == "") return "";
            }
        }

        return pre;
    }
}