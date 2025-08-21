using Infrastructure;

namespace TopInterview150.Divide_Conquer
{
    public static class MergekSortedLists
    {
        /// <summary>
        /// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
        /// Merge all the linked-lists into one sorted linked-list and return it.
        /// </summary>
        public static ListNode Execute(ListNode[] lists)
        {
            var startNode = new ListNode();
            var nextNode = startNode;
            var priorityQueue = new PriorityQueue<ListNode, int>();
            foreach (ListNode list in lists)
            {
                if (list == null)
                    continue;
                priorityQueue.Enqueue(list, list.Value);
            }

            while (priorityQueue.Count > 0)
            {
                var lightNode = priorityQueue.Dequeue();
                var nextLightNode = lightNode.Next;
                lightNode.Next = null;
                nextNode.Next = lightNode;
                nextNode = nextNode.Next;
                if (nextLightNode == null)
                    continue;
                priorityQueue.Enqueue(nextLightNode, nextLightNode.Value);
            }

            return startNode.Next;
        }

        public static IEnumerable<(ListNode[] lists, int[] answer)> GetTests()
        {
            yield return (
                new ListNode[]
                {
                    ListNode.Map(1, 4, 5),
                    ListNode.Map(1, 3, 4),
                    ListNode.Map(2, 6)
                },
                new int[] { 1, 1, 2, 3, 4, 4, 5, 6 });
            yield return (
                new ListNode[0],
                new int[0]);
            yield return (
                new ListNode[] { ListNode.Map() },
                new int[0]);
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
}
