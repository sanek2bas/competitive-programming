using Interview.Infrastructure;

namespace Interview.LinkedList
{
    public static class LinkedListCycle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool Execute(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (slow != null && fast?.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if(slow == fast)
                    return true;
            }
            return false;
        }
        public static IEnumerable<(ListNode node, bool answer)> GetTests()
        {
            yield return (ListNode.CreateCycleListNode(new int[] {3, 2, 0, -4}, 1), true);
            yield return (ListNode.CreateCycleListNode(new int[] {1, 2}, 0), true);
            yield return (ListNode.CreateCycleListNode(new int[] {1}, -1), false);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}