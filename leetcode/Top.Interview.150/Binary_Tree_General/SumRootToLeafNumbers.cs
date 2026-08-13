using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_General;

public class SumRootToLeafNumbers
{
    /// <summary>
    /// # 129
    /// https://leetcode.com/problems/sum-root-to-leaf-numbers/description/
    /// You are given the root of a binary tree containing digits from 0 to 9 only.
    /// Each root-to-leaf path in the tree represents a number.
    /// For example, the root-to-leaf path 1 -> 2 -> 3 represents the number 123.
    /// Return the total sum of all root-to-leaf numbers. Test cases are 
    /// generated so that the answer will fit in a 32-bit integer.
    /// A leaf node is a node with no children.
    /// </summary>
    public int Execute(TreeNode root)
    {
        return DFS(root, 0);
    }

    private int DFS(TreeNode node, int currentSum) 
    {
        if (node == null) 
            return 0;

        currentSum = currentSum * 10 + node.Value;

        if (node.Left == null 
            && node.Right == null) 
            return currentSum;

        return DFS(node.Left, currentSum) 
             + DFS(node.Right, currentSum);
    }
}