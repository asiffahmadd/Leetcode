public class Solution
{
    public bool CheckOverlap(
        int radius,
        int xCenter,
        int yCenter,
        int x1,
        int y1,
        int x2,
        int y2)
    {
        // Find the closest point on the rectangle to the circle center
        int closestX = Math.Max(x1, Math.Min(xCenter, x2));
        int closestY = Math.Max(y1, Math.Min(yCenter, y2));

        // Distance between circle center and closest rectangle point
        long dx = xCenter - closestX;
        long dy = yCenter - closestY;

        long distanceSquared = dx * dx + dy * dy;

        return distanceSquared <= (long)radius * radius;
    }
}