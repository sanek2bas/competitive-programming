using Interview.Infrastructure;

namespace Interview.LinkedList
{
    public static class ReverseLinkedList
    {
        public static ListNode Execute(ListNode head)
        {
            ListNode rev = null;

            while (head != null)
            {
                var tmp = head.Next;
                head.Next = rev;
                rev = head;
                head = tmp;
            }

            return rev;
        }

        public static IEnumerable<(ListNode node, int[] answer)> GetTests()
        {
            yield return (ListNode.CreateListNode(1, 2, 3, 4, 5), 
                          new int[] {5, 4, 3, 2, 1});
            yield return (ListNode.CreateListNode(1, 2), 
                          new int[] {2, 1});
            yield return (null, Array.Empty<int>());
        }

        public static bool CheckResult(ListNode result, int[] answer)
        {
            if (result == null && answer.Length == 0)
                return true;

            int i = 0;
            while(result != null)
            {
                if(result.Value != answer[i])
                    return false;
                result = result.Next;
                i++;
            }
            return i == answer.Length;
        }
    }
}
