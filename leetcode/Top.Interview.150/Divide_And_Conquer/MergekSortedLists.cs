using Top.Interview._150.Common;

public class MergekSortedLists
{
    /// <summary>
    /// # 23
    /// https://leetcode.com/problems/merge-k-sorted-lists/description/
    /// You are given an array of k linked-lists lists, 
    /// each linked-list is sorted in ascending order.
    /// Merge all the linked-lists into one sorted linked-list and return it.
    /// </summary>
    public ListNode Execute(ListNode[] lists)
    {
        var startNode = CreateListNode(-1);
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

    private ListNode CreateListNode(int number)
    {
        return ListNode.Create(number);
    }
}