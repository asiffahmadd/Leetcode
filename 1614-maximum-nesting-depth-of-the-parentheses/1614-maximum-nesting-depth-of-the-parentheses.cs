
public class Solution
{
    public int MaxDepth(string s)
    {
        int depth = 0;
        int maxDepth = 0;

        foreach (char ch in s)
        {
            if (ch == '(')
            {
                depth++;

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                }
            }
            else if (ch == ')')
            {
                depth--;
            }
        }

        return maxDepth;
    }
}

