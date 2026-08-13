public class Solution
{
    public int MaxPoints(int[][] points)
    {
        int n = points.Length;

        if (n <= 2)
            return n;

        int maxPoints = 2;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int count = 2;

                int x1 = points[i][0];
                int y1 = points[i][1];

                int x2 = points[j][0];
                int y2 = points[j][1];

                int dx = x2 - x1;
                int dy = y2 - y1;

                for (int k = j + 1; k < n; k++)
                {
                    int x3 = points[k][0];
                    int y3 = points[k][1];

                    int dx2 = x3 - x1;
                    int dy2 = y3 - y1;

                    if (dy * dx2 == dy2 * dx)
                    {
                        count++;
                    }
                }

                maxPoints = Math.Max(maxPoints, count);
            }
        }

        return maxPoints;
    }
}