public class Solution
{
    public bool SumGame(string num)
    {
        int n = num.Length;
        int half = n / 2;

        int leftSum = 0;
        int rightSum = 0;
        int leftQ = 0;
        int rightQ = 0;

        for (int i = 0; i < half; i++)
        {
            if (num[i] == '?')
                leftQ++;
            else
                leftSum += num[i] - '0';
        }

        for (int i = half; i < n; i++)
        {
            if (num[i] == '?')
                rightQ++;
            else
                rightSum += num[i] - '0';
        }

        int qDiff = leftQ - rightQ;
        int sumDiff = leftSum - rightSum;

        // Alice can force a win when the number of '?' is unbalanced.
        if (qDiff != 0)
        {
            // If the difference is odd, Alice always wins.
            if (Math.Abs(qDiff) % 2 == 1)
                return true;

            // Bob can win only when the sum difference
            // is exactly the required compensation.
            return sumDiff != -(qDiff / 2) * 9;
        }

        // Equal number of '?' on both sides.
        return sumDiff != 0;
    }
}