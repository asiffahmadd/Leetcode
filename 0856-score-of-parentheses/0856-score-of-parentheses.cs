public class Solution
{
    public int ScoreOfParentheses(string s)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(0);

        foreach (char c in s)
        {
            if (c == '(')
            {
                stack.Push(0);
            }
            else
            {
                int inner = stack.Pop();

                int score = inner == 0 ? 1 : 2 * inner;

                stack.Push(stack.Pop() + score);
            }
        }

        return stack.Pop();
    }
}