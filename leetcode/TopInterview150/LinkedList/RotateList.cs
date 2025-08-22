using System;
using Infrastructure;

namespace TopInterview150.LinkedList;

public class RotateList
{
    /// <summary>
    /// Given the head of a linked list, rotate the list to the right by k places.
    /// </summary>
    public static ListNode Execute(ListNode head, int k)
    {
        if (head == null ||
            head.Next == null ||
            k == 0)
            return head;

        int length = 1;
        ListNode tail = head;
        for(; tail.Next != null; tail = tail.Next)
            ++length;
        
        tail.Next = head;

        int t = length - k % length;
        for (int i = 0; i < t; i++)
            tail = tail.Next;
        
        ListNode newHead = tail.Next;
        tail.Next = null;

        return newHead;
    }

    public static IEnumerable<(ListNode head, int k, int[] answer)> GetTests()
    {
        yield return (
            ListNode.Map(1, 2, 3, 4, 5), 
            2, 
            new int[] { 4, 5, 1, 2, 3 });
        yield return (
            ListNode.Map(0, 1, 2), 
            4,
            new int[] {2, 0, 1});
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
