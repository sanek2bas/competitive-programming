using Infrastructure;

namespace TopInterview150.LinkedList;

public class PartitionList
{
    /// <summary>
    /// Given the head of a linked list and a value x, 
    /// partition it such that all nodes less than x come before nodes 
    /// greater than or equal to x.
    /// You should preserve the original relative order of the nodes in each of the two partitions.
    /// </summary>
    public static ListNode Execute(ListNode head, int x)
    {
        var beforeHead = new ListNode();
        var afterHead = new ListNode();
        ListNode before = beforeHead;
        ListNode after = afterHead;

        for (; head != null; head = head.Next)
        {
            if (head.Value < x)
            {
                before.Next = head;
                before = head;
            }
            else
            {
                after.Next = head;
                after = head;
            }
        }

        after.Next = null;
        before.Next = afterHead.Next;

        return beforeHead.Next;
    }

    public static IEnumerable<(ListNode head, int x, int[] answer)> GetTests()
    {
        yield return (
            ListNode.Map(1, 4, 3, 2, 5, 2), 
            3, 
            new int[] { 1, 2, 2, 4, 3, 5 });
        yield return (
            ListNode.Map(2, 1), 
            2,
            new int[] { 1, 2 });
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
