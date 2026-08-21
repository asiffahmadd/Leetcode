public class Solution
{
    public long FindKthSmallest(int[] coins, int k)
    {
        long left = 1;
        long right = (long)coins.Min() * k;

        while (left < right)
        {
            long mid = left + (right - left) / 2;

            if (CountAmounts(mid, coins) >= k)
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }

    private long CountAmounts(long x, int[] coins)
    {
        int n = coins.Length;
        long count = 0;

        // Inclusion-Exclusion
        for (int mask = 1; mask < (1 << n); mask++)
        {
            long lcm = 1;
            int bits = 0;
            bool overflow = false;

            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    bits++;

                    long g = GCD(lcm, coins[i]);
                    long next = lcm / g * coins[i];

                    if (next > x)
                    {
                        overflow = true;
                        break;
                    }

                    lcm = next;
                }
            }

            if (overflow || lcm > x)
                continue;

            long subsetCount = x / lcm;

            if (bits % 2 == 1)
                count += subsetCount;
            else
                count -= subsetCount;
        }

        return count;
    }

    private long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = a % b;
            a = b;
            b = temp;
        }

        return a;
    }
}