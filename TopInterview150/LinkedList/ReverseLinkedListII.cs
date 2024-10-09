using Infrastructure;

namespace TopInterview150.LinkedList;

public class ReverseLinkedListII
{
    /// <summary>
    /// Given a triangle array, return the minimum path sum from top to bottom.
    /// For each step, you may move to an adjacent number of the row below. 
    /// More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.
    /// </summary>
    public static ListNode Execute(ListNode head, int left, int right)
    {
        if (head == null ||
            left == right)
            return head;
            
        ListNode prev = head;        
        for (int i = 0; i < left - 1; ++i)
            prev = prev.Next;

        ListNode tail = prev.Next;
        for (int i = 0; i < right - left; i++) 
        {
            ListNode cache = tail.Next;
            tail.Next = cache.Next;
            cache.Next = prev.Next;
            prev.next = cache;
        }
    }

    public static IEnumerable<(ListNode head, int left, int right, int[] answer)> GetTests()
    {
        yield return (ListNode.Map(1, 2, 3, 4, 5), 2, 4, new int[] { 1, 4, 3, 5, 4 });
        yield return (ListNode.Map(5), 1, 1, new int[] { 5 });
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
