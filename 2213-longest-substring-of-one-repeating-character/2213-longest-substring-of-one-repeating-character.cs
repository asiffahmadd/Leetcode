public class Solution
{
    class Node
    {
        public int LeftChar;
        public int RightChar;
        public int Prefix;
        public int Suffix;
        public int Best;
        public int Length;

        public Node(int ch)
        {
            LeftChar = ch;
            RightChar = ch;
            Prefix = 1;
            Suffix = 1;
            Best = 1;
            Length = 1;
        }
    }

    private Node[] tree;
    private char[] arr;

    public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices)
    {
        int n = s.Length;
        int k = queryIndices.Length;

        arr = s.ToCharArray();
        tree = new Node[4 * n];

        Build(1, 0, n - 1);

        int[] result = new int[k];

        for (int i = 0; i < k; i++)
        {
            int index = queryIndices[i];
            char newChar = queryCharacters[i];

            arr[index] = newChar;

            Update(1, 0, n - 1, index);

            result[i] = tree[1].Best;
        }

        return result;
    }

    private void Build(int node, int start, int end)
    {
        if (start == end)
        {
            tree[node] = new Node(arr[start] - 'a');
            return;
        }

        int mid = start + (end - start) / 2;

        Build(node * 2, start, mid);
        Build(node * 2 + 1, mid + 1, end);

        tree[node] = Merge(tree[node * 2], tree[node * 2 + 1]);
    }

    private void Update(int node, int start, int end, int index)
    {
        if (start == end)
        {
            tree[node] = new Node(arr[index] - 'a');
            return;
        }

        int mid = start + (end - start) / 2;

        if (index <= mid)
            Update(node * 2, start, mid, index);
        else
            Update(node * 2 + 1, mid + 1, end, index);

        tree[node] = Merge(tree[node * 2], tree[node * 2 + 1]);
    }

    private Node Merge(Node left, Node right)
    {
        Node result = new Node(0);

        result.Length = left.Length + right.Length;

        result.LeftChar = left.LeftChar;
        result.RightChar = right.RightChar;

        result.Prefix = left.Prefix;

        result.Suffix = right.Suffix;

        result.Best = Math.Max(left.Best, right.Best);

        // If both boundary characters are same,
        // suffix of left + prefix of right can be combined.
        if (left.RightChar == right.LeftChar)
        {
            result.Best = Math.Max(
                result.Best,
                left.Suffix + right.Prefix
            );

            if (left.Prefix == left.Length)
            {
                result.Prefix = left.Length + right.Prefix;
            }

            if (right.Suffix == right.Length)
            {
                result.Suffix = right.Length + left.Suffix;
            }
        }

        return result;
    }
}