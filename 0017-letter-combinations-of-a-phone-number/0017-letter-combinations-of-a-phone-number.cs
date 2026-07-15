public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        List<string> result = new List<string>();

        string[] phone =
        {
            "", "", "abc", "def",
            "ghi", "jkl", "mno",
            "pqrs", "tuv", "wxyz"
        };

        Solve(digits, 0, "", phone, result);

        return result;
    }

    private void Solve(
        string digits,
        int index,
        string current,
        string[] phone,
        List<string> result)
    {
        if (index == digits.Length)
        {
            result.Add(current);
            return;
        }

        int digit = digits[index] - '0';
        string letters = phone[digit];

        foreach (char ch in letters)
        {
            Solve(
                digits,
                index + 1,
                current + ch,
                phone,
                result
            );
        }
    }
}