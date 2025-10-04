using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral;

public class ConstructBinaryTreeFromPreorderAndInorderTraversal
{
    /// <summary>
    /// Given two integer arrays preorder and inorder where preorder is the 
    /// preorder traversal of a binary tree and inorder is the inorder traversal
    ///  of the same tree, construct and return the binary tree.
    /// </summary>
    public static TreeNode Execute(int[] preorder, int[] inorder)
    {
        var inorderToIndex = new Dictionary<int, int>();

        for (int i = 0; i < inorder.Length; i++)
            inorderToIndex.Add(inorder[i], i);
        
        return Build(preorder, 0, preorder.Length - 1,
                     inorder, 0, inorder.Length - 1,
                     inorderToIndex);
    }

    private static TreeNode Build(int[] preorder, int preStart, int preEnd,
                                  int[] inorder, int inStart, int inEnd,
                                  Dictionary<int, int> inorderToIndex)
    {
        if (preStart > preEnd)
            return null;
        
        int rootVal = preorder[preStart];
        int rootInIndex = inorderToIndex[rootVal];
        int leftSize = rootInIndex - inStart;

        var root = new TreeNode(rootVal);
        root.Left = Build(preorder, preStart + 1, preStart + leftSize, 
                          inorder, inStart, rootInIndex - 1, 
                          inorderToIndex);
        root.Right = Build(preorder, preStart + leftSize + 1, preEnd,
                           inorder, rootInIndex + 1, inEnd,
                           inorderToIndex);
        
        return root;
    }

    public static IEnumerable<(int[] preorder, int[] inorder, TreeNode answer)> GetTests()
    {
        yield return (
            new int[] { 3, 9, 20, 15, 7 },
            new int[] { 9, 3, 15, 20, 7 },
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
