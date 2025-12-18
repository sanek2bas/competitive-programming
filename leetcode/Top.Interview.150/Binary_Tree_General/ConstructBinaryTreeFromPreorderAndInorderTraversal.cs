using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_General;

public class ConstructBinaryTreeFromPreorderAndInorderTraversal
{
    /// <summary>
    /// # 105
    /// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/description/
    /// Given two integer arrays preorder and inorder where preorder 
    /// is the preorder traversal of a binary tree and inorder 
    /// is the inorder traversal of the same tree, construct 
    /// and return the binary tree.
    /// </summary>
    public TreeNode Execute(int[] preorder, int[] inorder)
    {
        var inorderToIndex = new Dictionary<int, int>();

        for (int i = 0; i < inorder.Length; i++)
            inorderToIndex.Add(inorder[i], i);
        
        return Build(preorder, 0, preorder.Length - 1,
                     inorder, 0, inorder.Length - 1,
                     inorderToIndex);
    }

    private TreeNode Build(int[] preorder, int preStart, int preEnd,
                                  int[] inorder, int inStart, int inEnd,
                                  Dictionary<int, int> inorderToIndex)
    {
        if (preStart > preEnd)
            return null;
        
        int rootVal = preorder[preStart];
        int rootInIndex = inorderToIndex[rootVal];
        int leftSize = rootInIndex - inStart;

        var root = CreateTreeNode(rootVal);
        root.Left = Build(preorder, preStart + 1, preStart + leftSize, 
                          inorder, inStart, rootInIndex - 1, 
                          inorderToIndex);
        root.Right = Build(preorder, preStart + leftSize + 1, preEnd,
                           inorder, rootInIndex + 1, inEnd,
                           inorderToIndex);
        
        return root;
    }

    private TreeNode CreateTreeNode(int num)
    {
        return TreeNode.Create(num);
    }
}