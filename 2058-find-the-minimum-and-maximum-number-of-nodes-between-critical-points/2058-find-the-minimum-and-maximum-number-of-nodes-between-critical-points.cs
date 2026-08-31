public class Solution
{
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        int index = 1;

        ListNode prev = head;
        ListNode curr = head.next;

        int first = -1;
        int last = -1;
        int prevCritical = -1;

        int minDistance = int.MaxValue;

        while (curr != null && curr.next != null)
        {
            // Check local maximum or local minimum
            bool isCritical =
                (curr.val > prev.val && curr.val > curr.next.val) ||
                (curr.val < prev.val && curr.val < curr.next.val);

            if (isCritical)
            {
                // First critical point
                if (first == -1)
                {
                    first = index;
                }
                else
                {
                    // Distance from previous critical point
                    minDistance = Math.Min(
                        minDistance,
                        index - prevCritical
                    );
                }

                prevCritical = index;
                last = index;
            }

            prev = curr;
            curr = curr.next;
            index++;
        }

        // Fewer than two critical points
        if (first == -1 || first == last)
        {
            return new int[] { -1, -1 };
        }

        int maxDistance = last - first;

        return new int[] { minDistance, maxDistance };
    }
}