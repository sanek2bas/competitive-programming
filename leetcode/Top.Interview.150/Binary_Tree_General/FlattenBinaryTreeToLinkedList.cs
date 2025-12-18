using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_General;

public class FlattenBinaryTreeToLinkedList
{
    /// <summary>
    /// # 114
    /// https://leetcode.com/problems/flatten-binary-tree-to-linked-list/description/
    /// Given the root of a binary tree, flatten the tree into a "linked list":
    /// The "linked list" should use the same TreeNode class where 
    /// the right child pointer points to the next node in the list
    ///  and the left child pointer is always null. The "linked list" 
    /// should be in the same order as a pre-order traversal of the binary tree.
    /// </summary>
    public void Execute(TreeNode root)
    {
        if (root == null)
            return;

        while (root != null)
        {
            if (root.Left != null)
            {
                TreeNode rightMost = root.Left;
                while (rightMost.Right != null)
                    rightMost = rightMost.Right;
                rightMost.Right = root.Right;
                root.Right = root.Left;
                root.Left = null;
            }
            root = root.Right;
        }
    }
}