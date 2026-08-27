public class Solution
{
    public string LexGreaterPermutation(string s, string target)
    {
        int n = s.Length;

        int[] freq = new int[26];

        foreach (char c in s)
        {
            freq[c - 'a']++;
        }

        // Try every position from right to left.
        // We want the longest possible prefix equal to target.
        for (int i = n - 1; i >= 0; i--)
        {
            int[] remaining = (int[])freq.Clone();

            // Use target[0..i-1] as prefix
            bool possible = true;

            for (int j = 0; j < i; j++)
            {
                int ch = target[j] - 'a';

                if (remaining[ch] == 0)
                {
                    possible = false;
                    break;
                }

                remaining[ch]--;
            }

            if (!possible)
                continue;

            int current = target[i] - 'a';

            // Find the smallest character greater than target[i]
            for (int ch = current + 1; ch < 26; ch++)
            {
                if (remaining[ch] == 0)
                    continue;

                StringBuilder ans = new StringBuilder();

                // Equal prefix
                for (int j = 0; j < i; j++)
                {
                    ans.Append(target[j]);
                }

                // Make it strictly greater
                ans.Append((char)('a' + ch));
                remaining[ch]--;

                // Remaining characters in ascending order
                for (int c = 0; c < 26; c++)
                {
                    while (remaining[c] > 0)
                    {
                        ans.Append((char)('a' + c));
                        remaining[c]--;
                    }
                }

                return ans.ToString();
            }
        }

        return "";
    }
}