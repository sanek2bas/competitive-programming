using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_General;

public class BinaryTreeMaximumPathSum
{
    /// <summary>
    /// # 124
    /// https://leetcode.com/problems/binary-tree-maximum-path-sum/description/
    /// A path in a binary tree is a sequence of nodes where each pair of 
    /// adjacent nodes in the sequence has an edge connecting them. 
    /// A node can only appear in the sequence at most once. 
    /// Note that the path does not need to pass through the root.
    /// The path sum of a path is the sum of the node's values in the path.
    /// Given the root of a binary tree, return the maximum path sum of any non-empty path.
    /// </summary>
    public int Execute(TreeNode root)
    {
        int result = root.Value;
        DFS(root, ref result);
        return result;
    }

    private int DFS(TreeNode root, ref int result)
    {
        if (root == null)
            return 0;
        
        int left = Math.Max(0, DFS(root.Left, ref result));
        int right = Math.Max(0, DFS(root.Right, ref result));

        result = Math.Max(result, left + right + root.Value);
        return root.Value + Math.Max(left, right);
    }
}