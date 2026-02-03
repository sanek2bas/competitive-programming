using Top.Interview._150.Common;

namespace Top.Interview._150.Divide_And_Conquer;

public class SortList
{
    /// <summary>
    /// # 148
    /// Given the head of a linked list, return the list after sorting it 
    /// in ascending order.
    /// </summary>
    public ListNode Execute(ListNode head)
    {
        if (head == null
            || head.Next == null)
            return head;
        
        ListNode slow = head;
        ListNode fast = head.Next;
        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        ListNode left = head;
        ListNode right = slow.Next;
        slow.Next = null;
        left = Execute(left);
        right = Execute(right);

        ListNode dummy = ListNode.Create(-1);
        ListNode tail = dummy;
        while (left != null && right != null)
        {
            if (left.Value <= right.Value)
            {
                tail.Next = left;
                left = left.Next;
            }
            else
            {
                tail.Next = right;
                right = right.Next;
            }
            tail = tail.Next;
        }
        tail.Next = left != null ? left : right;
        return dummy.Next;
    }
}