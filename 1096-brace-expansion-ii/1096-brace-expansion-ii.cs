public class Solution
{
    private string expression;
    private int index;

    public IList<string> BraceExpansionII(string expression)
    {
        this.expression = expression;
        this.index = 0;

        HashSet<string> result = ParseExpression();

        List<string> answer = new List<string>(result);
        answer.Sort();

        return answer;
    }

    // Handles union: a,b,c
    private HashSet<string> ParseExpression()
    {
        HashSet<string> result = ParseTerm();

        while (index < expression.Length && expression[index] == ',')
        {
            index++; // skip ','

            HashSet<string> next = ParseTerm();

            result.UnionWith(next);
        }

        return result;
    }

    // Handles concatenation: ab, a{b,c}, {a,b}{c,d}
    private HashSet<string> ParseTerm()
    {
        HashSet<string> result = new HashSet<string> { "" };

        while (index < expression.Length &&
               expression[index] != '}' &&
               expression[index] != ',')
        {
            HashSet<string> next = ParseFactor();

            result = Multiply(result, next);
        }

        return result;
    }

    // Handles a single letter or {...}
    private HashSet<string> ParseFactor()
    {
        // Case 1: { ... }
        if (expression[index] == '{')
        {
            index++; // skip '{'

            HashSet<string> result = ParseExpression();

            index++; // skip '}'

            return result;
        }

        // Case 2: lowercase letter
        char ch = expression[index];

        index++;

        return new HashSet<string> { ch.ToString() };
    }

    // Cartesian product / concatenation
    private HashSet<string> Multiply(
        HashSet<string> first,
        HashSet<string> second)
    {
        HashSet<string> result = new HashSet<string>();

        foreach (string a in first)
        {
            foreach (string b in second)
            {
                result.Add(a + b);
            }
        }

        return result;
    }
}