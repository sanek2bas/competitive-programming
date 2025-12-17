using Top.Interview._150.Common;

namespace Top.Interview._150.Linked_List;

public class MergeTwoSortedLists
{
    /// <summary>
    /// # 21
    /// https://leetcode.com/problems/merge-two-sorted-lists/description/
    /// You are given the heads of two sorted linked lists list1 and list2.
    /// Merge the two lists into one sorted list.The list should be made 
    /// by splicing together the nodes of the first two lists.
    /// Return the head of the merged linked list.
    /// </summary>
    public ListNode<int>? Execute(ListNode<int> list1, ListNode<int> list2)
    {
        if (list1 == null 
            || list2 == null)
            return list1 == null ? list2 : list1;

        if (list1.Value > list2.Value)
        {
            ListNode<int> temp = list1;
            list1 = list2;
            list2 = temp;
        }

        list1.Next = Execute(list1.Next, list2);
        return list1;
    }
}
