using Interview.Infrastructure;

namespace Interview.LinkedList
{
    public class MergeSortedLists
    {
        /// <summary>
        /// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
        /// Merge all the linked-lists into one sorted linked-list and return it.
        /// </summary>
        /// <param name="nodes">
        /// Linked-lists lists
        /// </param>
        /// <returns>ListNode</returns>
        public static ListNode? Execute(ListNode[] nodes)
        {
            var startNode = new ListNode();
            var nextNode = startNode;
            var priorityQueue = new PriorityQueue<ListNode, int>();
            foreach (ListNode node in nodes)
            {
                if(node == null)
                    continue;
                priorityQueue.Enqueue(node, node.Value);
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

        public static IEnumerable<(ListNode[] nodes, int[] answer)> GetTests()
        {
            yield return (
                new ListNode[]
                {
                    ListNode.CreateListNode(1, 4, 5),
                    ListNode.CreateListNode(1, 3, 4),
                    ListNode.CreateListNode(2, 6) 
                },
                new int[] { 1, 1, 2, 3, 4, 4, 5, 6 });
            yield return (Array.Empty<ListNode>(), Array.Empty<int>());
        }

        public static bool CheckResult(ListNode result, int[] answer)
        {
            for (int i = 0; i < answer.Length; i++)
            {
                if(result == null)
                    return false;
                if (answer[i] != result.Value)
                    return false;
                result = result.Next;
            }
            return true;
        }
    }
}
