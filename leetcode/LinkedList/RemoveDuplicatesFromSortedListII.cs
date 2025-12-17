using System;
using Infrastructure;

namespace TopInterview150.LinkedList;

public class RemoveDuplicatesFromSortedListII
{
    

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
