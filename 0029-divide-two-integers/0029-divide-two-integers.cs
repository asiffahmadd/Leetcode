public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        // Overflow case
        if (dividend == int.MinValue && divisor == -1)
            return int.MaxValue;

        // Determine sign
        bool isNegative = (dividend < 0) ^ (divisor < 0);

        long dvd = Math.Abs((long)dividend);
        long dvs = Math.Abs((long)divisor);

        int result = 0;

        while (dvd >= dvs)
        {
            long temp = dvs;
            int multiple = 1;

            while (dvd >= (temp << 1))
            {
                temp <<= 1;
                multiple <<= 1;
            }

            dvd -= temp;
            result += multiple;
        }

        return isNegative ? -result : result;
    }
}