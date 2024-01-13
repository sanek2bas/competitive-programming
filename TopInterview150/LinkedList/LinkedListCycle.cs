using Infrastructure;

namespace TopInterview150.LinkedList
{
    public static class LinkedListCycle
    {
        /// <summary>
        /// Given head, the head of a linked list, determine if the linked list has a cycle in it.
        /// There is a cycle in a linked list if there is some node in the list that can be reached 
        /// again by continuously following the next pointer.Internally, pos is used to denote 
        /// the index of the node that tail's next pointer is connected to. 
        /// Note that pos is not passed as a parameter.
        /// Return true if there is a cycle in the linked list.Otherwise, return false.
        /// </summary>
        public static bool Execute(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (slow != null && fast?.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast)
                    return true;
            }
            return false;
        }

        public static IEnumerable<(ListNode node, bool answer)> GetTests()
        {
            yield return (ListNode.Map(new int[] { 3, 2, 0, -4 }, 1), true);
            yield return (ListNode.Map(new int[] { 1, 2 }, 0), true);
            yield return (ListNode.Map(new int[] { 1 }, -1), false);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}
