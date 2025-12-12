using Top.Interview._150.Common;

namespace Top.Interview._150.Linked_List;

public class RotateList
{
    /// <summary>
    /// # 61
    /// https://leetcode.com/problems/rotate-list/description/
    /// Given the head of a linked list, 
    /// rotate the list to the right by k places.
    /// </summary>
    public ListNode Execute(ListNode head, int k)
    {
        if (head == null
            || head.Next == null
            || k == 0)
            return head;

        int length = 1;
        ListNode tail = head;
        for (; tail.Next != null; tail = tail.Next)
            ++length;

        tail.Next = head;

        int t = length - k % length;
        for (int i = 0; i < t; i++)
            tail = tail.Next;

        ListNode newHead = tail.Next;
        tail.Next = null;

        return newHead;
    }
}