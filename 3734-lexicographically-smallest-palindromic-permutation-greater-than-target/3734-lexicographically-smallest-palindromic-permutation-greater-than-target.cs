public class Solution
{
    public string LexPalindromicPermutation(string s, string target)
    {
        int n = s.Length;
        int[] freq = new int[26];

        foreach (char c in s)
            freq[c - 'a']++;

        // A palindrome can have at most one odd frequency.
        int odd = 0;
        char middle = '\0';

        for (int i = 0; i < 26; i++)
        {
            if (freq[i] % 2 == 1)
            {
                odd++;
                middle = (char)('a' + i);
            }
        }

        if (odd > 1)
            return "";

        // Frequency for the first half.
        int[] halfFreq = new int[26];

        for (int i = 0; i < 26; i++)
            halfFreq[i] = freq[i] / 2;

        int halfLen = n / 2;
        string targetHalf = target.Substring(0, halfLen);

        // -------------------------------------------------
        // CASE 1:
        // Try to make the first half exactly equal
        // to target's first half.
        // -------------------------------------------------

        int[] remaining = (int[])halfFreq.Clone();
        bool possible = true;

        for (int i = 0; i < halfLen; i++)
        {
            int idx = targetHalf[i] - 'a';

            if (remaining[idx] == 0)
            {
                possible = false;
                break;
            }

            remaining[idx]--;
        }

        if (possible)
        {
            string candidate = BuildPalindrome(targetHalf, middle);

            // Important:
            // Even if the first half is equal, the complete
            // palindrome can still be greater than target.
            //
            // Example:
            // s = "bb", target = "ba"
            // candidate = "bb" > "ba"
            if (string.Compare(candidate, target, StringComparison.Ordinal) > 0)
                return candidate;
        }

        // -------------------------------------------------
        // CASE 2:
        // Find the smallest first-half permutation
        // strictly greater than targetHalf.
        // -------------------------------------------------

        string nextHalf = FindNextGreater(targetHalf, halfFreq);

        if (nextHalf == null)
            return "";

        return BuildPalindrome(nextHalf, middle);
    }

    private string FindNextGreater(string targetHalf, int[] freq)
    {
        int len = targetHalf.Length;

        // Change the rightmost possible character.
        for (int pos = len - 1; pos >= 0; pos--)
        {
            int[] remaining = (int[])freq.Clone();

            bool possible = true;

            // Keep everything before pos equal to target.
            for (int i = 0; i < pos; i++)
            {
                int idx = targetHalf[i] - 'a';

                if (remaining[idx] == 0)
                {
                    possible = false;
                    break;
                }

                remaining[idx]--;
            }

            if (!possible)
                continue;

            int targetChar = targetHalf[pos] - 'a';

            // Choose the smallest character greater than target[pos].
            for (int c = targetChar + 1; c < 26; c++)
            {
                if (remaining[c] > 0)
                {
                    remaining[c]--;

                    string result = targetHalf.Substring(0, pos);
                    result += (char)('a' + c);

                    // Put remaining characters in ascending order.
                    for (int x = 0; x < 26; x++)
                    {
                        result += new string(
                            (char)('a' + x),
                            remaining[x]
                        );
                    }

                    return result;
                }
            }
        }

        return null;
    }

    private string BuildPalindrome(string half, char middle)
    {
        char[] chars = half.ToCharArray();
        Array.Reverse(chars);

        string right = new string(chars);

        if (middle != '\0')
            return half + middle + right;

        return half + right;
    }
}