
public class Solution
{
    public string Evaluate(string s, IList<IList<string>> knowledge)
    {
        // Store knowledge in Dictionary for O(1) lookup
        Dictionary<string, string> map = new Dictionary<string, string>();

        foreach (var item in knowledge)
        {
            map[item[0]] = item[1];
        }

        StringBuilder result = new StringBuilder();

        int i = 0;

        while (i < s.Length)
        {
            // Normal character
            if (s[i] != '(')
            {
                result.Append(s[i]);
                i++;
            }
            else
            {
                // Find closing bracket
                int j = i + 1;

                while (s[j] != ')')
                {
                    j++;
                }

                // Extract key
                string key = s.Substring(i + 1, j - i - 1);

                // Check if key exists
                if (map.ContainsKey(key))
                {
                    result.Append(map[key]);
                }
                else
                {
                    result.Append('?');
                }

                // Move i after ')'
                i = j + 1;
            }
        }

        return result.ToString();
    }
}
