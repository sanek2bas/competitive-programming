using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_General;

public class ConstructBinaryTreeFromInorderAndPostorderTraversal
{
    /// <summary>
    /// # 106
    /// https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/description/
    /// Given two integer arrays inorder and postorder where inorder is 
    /// the inorder traversal of a binary tree and postorder is 
    /// the postorder traversal of the same tree, construct and return the 
    /// binary tree.
    /// </summary>
    public TreeNode Execute(int[] inorder, int[] postorder)
    {
        var inorderToIndex = new Dictionary<int, int>();

        for (int i = 0; i < inorder.Length; i++)
            inorderToIndex.Add(inorder[i], i);
        
        return Build(inorder, 0, inorder.Length - 1,
                     postorder, 0, postorder.Length - 1,
                     inorderToIndex);
    }

    private TreeNode Build(int[] inorder, int inStart, int inEnd,
                                  int[] postorder, int postStart, int postEnd,
                                  Dictionary<int, int> inorderToIndex)
    {
        if (inStart > inEnd)
            return null;
        
        int rootVal = postorder[postEnd];
        int rootInIndex = inorderToIndex[rootVal];
        int leftSize = rootInIndex - inStart;

        var root = CreateTreeNode(rootVal);
        root.Left = Build(inorder, inStart, rootInIndex - 1, 
                          postorder, postStart, postStart + leftSize - 1,
                          inorderToIndex);
        root.Right = Build(inorder, rootInIndex + 1, inEnd,
                           postorder, postStart + leftSize, postEnd - 1, 
                           inorderToIndex);
        
        return root;
    }

    private TreeNode CreateTreeNode(int num)
    {
        return TreeNode.Create(num);
    }
}