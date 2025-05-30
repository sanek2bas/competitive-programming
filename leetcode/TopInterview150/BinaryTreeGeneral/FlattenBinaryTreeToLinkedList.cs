using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral;

public class FlattenBinaryTreeToLinkedList
{
    /// <summary>
    /// Given the root of a binary tree, flatten the tree into a "linked list":
    /// The "linked list" should use the same TreeNode class where the right child 
    /// pointer points to the next node in the list and the left child pointer is always null.
    /// The "linked list" should be in the same order as a pre-order traversal of the binary tree.
    /// </summary>
    public static void Execute(TreeNode root)
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

    public static IEnumerable<(TreeNode root, int?[] answer)> GetTests()
    {
        yield return (
            TreeNode.Map(1, 2, 5, 3, 4, null, 6),
            new int?[] { 1, null, 2, null, 3, null, 4, null, 5, null, 6 });
        yield return (
            TreeNode.Map(),
            new int?[] { });
        yield return (
            TreeNode.Map(0),
            new int?[] { 0 });
    }

    public static bool CheckResult(TreeNode result, int?[] answer)
    {
        if (result == null)
            return answer.Length == 0;

        int idx = 0;
        while (result != null)
        {
            if (result.Value != answer[idx])
                return false;
            if (result.Left != null)
                return false;
            idx++;           
            if (answer.Length < idx &&
                answer[idx] != null)
                return false;
            result = result.Right;
            idx++;
        }
        return answer.Length <= idx;
    }
}
