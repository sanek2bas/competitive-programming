using System;
using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral;

public class ConstructBinaryTreeFromInorderAndPostorderTraversal
{
    /// <summary>
    /// Given two integer arrays inorder and postorder where inorder is 
    /// the inorder traversal of a binary tree and postorder is 
    /// the postorder traversal of the same tree, construct and return the 
    /// binary tree.
    /// </summary>
    public static TreeNode Execute(int[] inorder, int[] postorder)
    {
        var inorderToIndex = new Dictionary<int, int>();

        for (int i = 0; i < inorder.Length; i++)
            inorderToIndex.Add(inorder[i], i);
        
        return Build(inorder, 0, inorder.Length - 1,
                     postorder, 0, postorder.Length - 1,
                     inorderToIndex);
    }

    private static TreeNode Build(int[] inorder, int inStart, int inEnd,
                                  int[] postorder, int postStart, int postEnd,
                                  Dictionary<int, int> inorderToIndex)
    {
        if (inStart > inEnd)
            return null;
        
        int rootVal = postorder[postEnd];
        int rootInIndex = inorderToIndex[rootVal];
        int leftSize = rootInIndex - inStart;

        var root = new TreeNode(rootVal);
        root.Left = Build(inorder, inStart, rootInIndex - 1, 
                          postorder, postStart, postStart + leftSize - 1,
                          inorderToIndex);
        root.Right = Build(inorder, rootInIndex + 1, inEnd,
                           postorder, postStart + leftSize, postEnd - 1, 
                           inorderToIndex);
        
        return root;
    }

    public static IEnumerable<(int[] inorder, int[] postorder, TreeNode answer)> GetTests()
    {
        yield return (
            new int[] { 9, 3, 15, 20, 7 },
            new int[] { 9, 15, 7, 20, 3 },
            TreeNode.Map(3, 9, 20, null, null, 15, 7));
        yield return (
            new int[] { -1 },
            new int[] { -1 },
            TreeNode.Map(-1));
    }

    public static bool CheckResult(TreeNode result, TreeNode answer)
    {
        return SameTree.Execute(result, answer);
    }
}
