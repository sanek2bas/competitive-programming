using Top.Interview._150.Common;

namespace Top.Interview._150.Linked_List;

public class ReverseLinkedList2
{
    /// <summary>
    /// # 92
    /// https://leetcode.com/problems/reverse-linked-list-ii/description/
    /// Given a triangle array, return the minimum path sum from top to bottom.
    /// For each step, you may move to an adjacent number of the row below. 
    /// More formally, if you are on index i on the current row, 
    /// you may move to either index i or index i + 1 on the next row.
    /// </summary>
    public ListNode Execute(ListNode head, int left, int right)
    {
        if (head == null ||
            left == right)
            return head;

        ListNode start = ListNode.Create(-1);
        start.Next = head;
        ListNode prev = start;

        for (int i = 1; i < left; i++)
            prev = prev.Next;

        ListNode current = prev.Next;
        ListNode next = null;

        for (int i = left; i < right; i++)
        {
            next = current.Next;
            current.Next = next.Next;
            next.Next = prev.Next;
            prev.Next = next;
        }

        return start.Next;
    }
}