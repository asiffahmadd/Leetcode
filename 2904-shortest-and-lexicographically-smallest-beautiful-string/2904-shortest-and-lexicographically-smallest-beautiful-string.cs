public class Solution
{
    public string ShortestBeautifulSubstring(string s, int k)
    {
        int left = 0;
        int ones = 0;

        string result = "";

        for (int right = 0; right < s.Length; right++)
        {
            if (s[right] == '1')
                ones++;

            // We have exactly k ones
            while (ones == k)
            {
                // Remove unnecessary leading zeros
                while (left <= right && s[left] == '0')
                {
                    left++;
                }

                string current = s.Substring(left, right - left + 1);

                // Update answer
                if (result == "" ||
                    current.Length < result.Length ||
                    (current.Length == result.Length &&
                     string.Compare(current, result, StringComparison.Ordinal) < 0))
                {
                    result = current;
                }

                // Move left past the first 1
                if (s[left] == '1')
                {
                    ones--;
                    left++;
                }
            }
        }

        return result;
    }
}