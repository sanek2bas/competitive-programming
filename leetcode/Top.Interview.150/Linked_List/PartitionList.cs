using Top.Interview._150.Common;

namespace Top.Interview._150.Linked_List;

public class PartitionList
{
    /// <summary>
    /// # 86
    /// https://leetcode.com/problems/partition-list/description/
    /// Given the head of a linked list and a value x, 
    /// partition it such that all nodes less than x come before nodes 
    /// greater than or equal to x.
    /// You should preserve the original relative order of 
    /// the nodes in each of the two partitions.
    /// </summary>
    public ListNode<int> Execute(ListNode<int> head, int x)
    {
        var beforeHead = ListNode<int>.Create(-1);
        var afterHead = ListNode<int>.Create(-1);
        ListNode<int> before = beforeHead;
        ListNode<int> after = afterHead;

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

}