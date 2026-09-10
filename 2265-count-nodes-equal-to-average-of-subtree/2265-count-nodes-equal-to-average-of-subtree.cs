public class Solution
{
    private int count = 0;

    public int AverageOfSubtree(TreeNode root)
    {
        DFS(root);
        return count;
    }

    private (int sum, int nodes) DFS(TreeNode node)
    {
        if (node == null)
            return (0, 0);

        var left = DFS(node.left);
        var right = DFS(node.right);

        int sum = node.val + left.sum + right.sum;
        int nodes = 1 + left.nodes + right.nodes;

        if (node.val == sum / nodes)
            count++;

        return (sum, nodes);
    }
}