public class Solution
{
    public long CountCommas(long n)
    {
        long result = 0;
        long start = 1000;
        long commas = 1;

        while (start <= n)
        {
            long end = start * 1000 - 1;

            // Avoid overflow
            if (end < start || end > n)
                end = n;

            long count = end - start + 1;

            result += count * commas;

            start *= 1000;
            commas++;
        }

        return result;
    }
}