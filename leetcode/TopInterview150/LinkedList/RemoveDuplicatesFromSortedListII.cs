using System;
using Infrastructure;

namespace TopInterview150.LinkedList;

public class RemoveDuplicatesFromSortedListII
{
    /// <summary>
    /// Given the head of a sorted linked list, 
    /// delete all nodes that have duplicate numbers, 
    /// leaving only distinct numbers from the original list. 
    /// Return the linked list sorted as well.
    /// </summary>
    public static ListNode Execute(ListNode head)
    {
        ListNode dummy = new ListNode();
        dummy.Next = head;
        ListNode prev = dummy;
        
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

    public static IEnumerable<(ListNode head, int[] answer)> GetTests()
    {
        yield return (
            ListNode.Map(1, 2, 3, 3, 4, 4, 5), 
            new int[] { 1, 2, 5 });
        yield return (
            ListNode.Map(1, 1, 1, 2, 3),
            new int[] { 2, 3});
    }

    public static bool CheckResult(ListNode result, int[] answer)
    {
        for (int i = 0; i < answer.Length; i++)
        {
            if (result == null)
                return false;
            if (result.Value != answer[i])
                return false;
            result = result.Next;
        }
        return result == null;
    }
}
