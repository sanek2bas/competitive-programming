using System.Globalization;
using System.Text;

namespace Interview.LinkedList
{
    public class MergeSortedLists
    {
        /// <summary>
        /// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
        /// Merge all the linked-lists into one sorted linked-list and return it.
        /// </summary>
        /// <param name="nodes"></param>
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

        public static string ConvertToString(ListNode node)
        {
            if (node == null)
            {
                return "[]";
            }

            StringBuilder answer = new StringBuilder();
            while (node != null)
            {
                answer.Append(node.Value.ToString());
                answer.Append("->");
                node = node.Next;
            }
            answer.Remove(answer.Length - 2, 2);
            return answer.ToString();
        }

        public static IEnumerable<(ListNode[] nodes, string answer)> GetTests()
        {
            yield return (new ListNode[] { createListNode(1,4,5), createListNode(1, 3, 4), createListNode(2, 6) }, "1->1->2->3->4->4->5->6");
            yield return (new ListNode[0], "[]");
        }

        private static ListNode? createListNode(params int[] numbers)
        {
            var startNode = new ListNode();
            var nextNode = startNode;
            foreach(int number in numbers)
            {
                nextNode.Next = new ListNode(number);
                nextNode = nextNode.Next;
            }
            return startNode.Next;
        }
    }

    public class ListNode
    {
        public int Value { get; init; }

        public ListNode? Next { get; set; }

        public ListNode(int value = -1, ListNode? next = null)
        {
            Value = value;
            Next = next;            
        }
    }
}
