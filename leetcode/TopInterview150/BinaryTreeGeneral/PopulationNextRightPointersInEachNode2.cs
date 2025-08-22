using System;
using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral;

public class PopulationNextRightPointersInEachNode2
{
    /// <summary>
    /// Populate each next pointer to point to its next right node.\
    /// If there is no next right node, the next pointer should be set to NULL.
    /// Initially, all next pointers are set to NULL.
    /// </summary>
    public static TreeListNode Execute(TreeListNode root)
    {
        TreeListNode node = root;

        while (node != null)
        {
            TreeListNode dummy = new TreeListNode();

            for (TreeListNode needle = dummy; node != null; node = node.Next)
            {
                if (node.Left != null)
                {
                    needle.Next = node.Left;
                    needle = needle.Next;
                }
                if (node.Right != null)
                {
                    needle.Next = node.Right;
                    needle = needle.Next;
                }
            }

            node = dummy.Next;
        }

        return root;
    }

    public static IEnumerable<(TreeListNode root, int?[] answer)> GetTests()
    {
        yield return (
            TreeListNode.Map(1, 2, 3, 4, 5, 6, 7),
            new int?[] { 1, null, 2, 3, null, 4, 5, 7, null });
        yield return (
            TreeListNode.Map(),
            new int?[] { });
    }

    public static bool CheckResult(TreeListNode result, int?[] answer)
    {
        if (result == null)
            return answer.Length == 0;

        int idx = 0;
        while (result != null)
        {
            if (result.Value != answer[idx])
                return false;
            idx++;
        }

        return idx >= answer.Length;
    }
}