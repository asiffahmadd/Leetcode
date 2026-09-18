public class Solution
{
    public IList<string> MaxNumOfSubstrings(string s)
    {
        int n = s.Length;

        // First and last occurrence of every character
        int[] first = new int[26];
        int[] last = new int[26];

        Array.Fill(first, -1);

        for (int i = 0; i < n; i++)
        {
            int c = s[i] - 'a';

            if (first[c] == -1)
                first[c] = i;

            last[c] = i;
        }

        // Find the smallest valid interval starting from index 'start'
        List<(int start, int end)> intervals = new();

        for (int c = 0; c < 26; c++)
        {
            if (first[c] == -1)
                continue;

            int start = first[c];
            int end = last[c];

            bool valid = true;

            for (int i = start; i <= end; i++)
            {
                int x = s[i] - 'a';

                // Character occurs before our current start.
                // Therefore this interval cannot be valid.
                if (first[x] < start)
                {
                    valid = false;
                    break;
                }

                // We must include ALL occurrences of this character.
                end = Math.Max(end, last[x]);
            }

            if (valid)
                intervals.Add((start, end));
        }

        // Greedy: choose interval with earliest ending position.
        intervals.Sort((a, b) => a.end.CompareTo(b.end));

        List<string> result = new();

        int prevEnd = -1;

        foreach (var interval in intervals)
        {
            if (interval.start > prevEnd)
            {
                result.Add(s.Substring(
                    interval.start,
                    interval.end - interval.start + 1
                ));

                prevEnd = interval.end;
            }
        }

        return result;
    }
}