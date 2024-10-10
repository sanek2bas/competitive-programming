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

        ListNode start = new ListNode();
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

    public static IEnumerable<(ListNode head, int left, int right, int[] answer)> GetTests()
    {
        yield return (ListNode.Map(1, 2, 3, 4, 5), 2, 4, new int[] { 1, 4, 3, 2, 5 });
        yield return (ListNode.Map(5), 1, 1, new int[] { 5 });
        yield return (ListNode.Map(3, 5), 1, 2, new int[] { 5, 3});
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
