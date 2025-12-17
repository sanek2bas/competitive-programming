using Top.Interview._150.Common;

namespace Top.Interview._150.Linked_List;

public class RemoveDuplicatesFromSortedList2
{
    /// <summary>
    /// # 82
    /// https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/description/
    /// Given the head of a sorted linked list, 
    /// delete all nodes that have duplicate numbers, 
    /// leaving only distinct numbers from the original list. 
    /// Return the linked list sorted as well.
    /// </summary>
    public ListNode<int> Execute(ListNode<int> head)
    {
        ListNode<int>? dummy = ListNode<int>.Create(-1);
        dummy.Next = head;
        ListNode<int>? prev = dummy;
        
        while (head != null)
        {
            while (head.Next != null &&
                   head.Value == head.Next.Value)
                head = head.Next;
            if (prev.Next == head)
                prev = prev.Next;
            else
                prev.Next = head.Next;
            head = head.Next;
        }

        return dummy.Next;
    }
}