
public class Solution {
    public string LargestEven(string s) {
        int lastTwo = s.LastIndexOf('2');
        if (lastTwo == -1) return "";
        return s.Substring(0, lastTwo + 1);
    }
}