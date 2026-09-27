
public class Solution
{
    public string ReverseParentheses(string s)
    {
        Stack<string> stack = new Stack<string>();

        StringBuilder current = new StringBuilder();

        foreach (char ch in s)
        {
            if (ch == '(')
            {
                // Save current string
                stack.Push(current.ToString());

                // Start a new string
                current.Clear();
            }
            else if (ch == ')')
            {
                // Reverse current string
                string reversed = Reverse(current.ToString());

                // Get the string before '('
                string previous = stack.Pop();

                // Combine them
                current = new StringBuilder(previous + reversed);
            }
            else
            {
                current.Append(ch);
            }
        }

        return current.ToString();
    }

    private string Reverse(string str)
    {
        char[] arr = str.ToCharArray();

        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            char temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;

            left++;
            right--;
        }

        return new string(arr);
    }
}

