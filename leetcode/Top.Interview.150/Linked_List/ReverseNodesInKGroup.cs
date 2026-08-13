using Top.Interview._150.Common;

namespace Top.Interview._150.Linked_List;

public class ReverseNodesInKGroup
{
    /// <summary>
    /// # 25
    /// https://leetcode.com/problems/reverse-nodes-in-k-group/description/
    /// Given the head of a linked list, reverse the nodes of the list 
    /// k at a time, and return the modified list.
    /// k is a positive integer and is less than or equal to the length 
    /// of the linked list. If the number of nodes is not a multiple of
    /// k then left-out nodes, in the end, should remain as it is.
    /// You may not alter the values in the list's nodes, only nodes themselves may be changed.
    /// </summary>
    public ListNode Execute(ListNode head, int k)
    {
        if (head == null 
            || k == 1)
            return head;

        int length = GetLength(head);
        ListNode dummy = ListNode.Create(0);
        dummy.Next = head;
        ListNode prev = dummy;
        ListNode curr = head;

        for (int i = 0; i < length / k; ++i)
        {
            for (int j = 0; j < k - 1; ++j) 
            {
                ListNode next = curr.Next;
                curr.Next = next.Next;
                next.Next = prev.Next;
                prev.Next = next;
            }
            prev = curr;
            curr = curr.Next;
        }

        return dummy.Next;
    }

    private int GetLength(ListNode head) 
    {
        int length = 0;
        for (ListNode curr = head; curr != null; curr = curr.Next)
            ++length;
        return length;
    }
}