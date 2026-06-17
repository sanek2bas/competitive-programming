using Top.Interview._150.Common;

namespace Top.Interview._150.Linked_List;

public class RemoveNthNodeFromEndOfList
{
    /// <summary>
    /// # 19
    /// https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/
    /// Given the head of a linked list, remove the nth node from the end 
    /// of the list and return its head.
    /// </summary>
    public ListNode Execute(ListNode head, int n)
    {
        ListNode slow = head;
        ListNode fast = head;

        while (n-- > 0)
            fast = fast.Next;
        if (fast == null)
            return head.Next;

        while (fast.Next != null) 
        {
            slow = slow.Next;
            fast = fast.Next;
        }
        slow.Next = slow.Next.Next;

        return head;
    }
}