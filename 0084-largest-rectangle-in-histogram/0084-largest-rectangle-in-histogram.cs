public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;

        for (int i = 0; i <= heights.Length; i++)
        {
            int currentHeight = i == heights.Length ? 0 : heights[i];

            while (stack.Count > 0 &&
                   heights[stack.Peek()] > currentHeight)
            {
                int height = heights[stack.Pop()];

                int width;

                if (stack.Count == 0)
                {
                    width = i;
                }
                else
                {
                    width = i - stack.Peek() - 1;
                }

                int area = height * width;

                if (area > maxArea)
                {
                    maxArea = area;
                }
            }

            stack.Push(i);
        }

        return maxArea;
    }
}