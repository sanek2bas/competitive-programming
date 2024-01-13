using Infrastructure;

namespace TopInterview150.LinkedList
{
    public static class MergeTwoSortedLists
    {
        /// <summary>You are given the heads of two sorted linked lists list1 and list2.
        /// Merge the two lists into one sorted list.The list should be made by splicing together the nodes of the first two lists.
        /// Return the head of the merged linked list.
        /// </summary>
        public static ListNode Execute(ListNode list1, ListNode list2)
        {
            if (list1 == null || list2 == null)
                return list1 == null ? list2 : list1;
            if (list1.Value > list2.Value)
            {
                ListNode temp = list1;
                list1 = list2;
                list2 = temp;
            }
            list1.Next = Execute(list1.Next, list2);
            return list1;
        }

        public static IEnumerable<(ListNode node1, ListNode node2, int[] answer)> GetTests()
        {
            yield return (
               ListNode.Map(1, 2, 4),
               ListNode.Map(1, 3, 4),
               new int[] { 1, 1, 2, 3, 4, 4 });
            yield return (
                ListNode.Map(),
                ListNode.Map(0),
                new int[] { 0 });
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
            return true;
        }
    }
}
