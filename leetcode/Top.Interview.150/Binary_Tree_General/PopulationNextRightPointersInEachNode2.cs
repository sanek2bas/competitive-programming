using Top.Interview._150.Common;

public class PopulationNextRightPointersInEachNode2
{
    /// <summary>
    /// # 117
    /// https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/description/
    /// Populate each next pointer to point to its next right node.
    /// If there is no next right node, the next pointer should be set to NULL.
    /// Initially, all next pointers are set to NULL.
    /// </summary>
    public TreeListNode Execute(TreeListNode root)
    {
        TreeListNode node = root;

        while (node != null)
        {
            TreeListNode dummy = CreateTreeListNode(-1);

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

    private TreeListNode CreateTreeListNode(params int?[] values)
    {
        return TreeListNode.Create(values);
    }
}