using Top.Interview._150.Common;

namespace Top.Interview._150.Linked_List;

public class AddTwoNumbers
{
    /// <summary>
    /// # 2
    /// https://leetcode.com/problems/add-two-numbers/description/
    /// You are given two non-empty linked lists representing 
    /// two non-negative integers. 
    /// The digits are stored in reverse order, and each of their 
    /// nodes contains a single digit. 
    /// Add the two numbers and return the sum as a linked list.
    /// You may assume the two numbers do not contain any leading zero, 
    /// except the number 0 itself.
    /// </summary>
    public ListNode<int> Execute(ListNode<int> l1, ListNode<int> l2)
    {
        var startNode = ListNode<int>.Create(-1);
        var curretNode = startNode;
        int carry = 0;
        while(l1 != null || l2 != null || carry > 0)
        {
            if(l1 != null)
            {
                carry += l1.Value;
                l1 = l1.Next;
            }
            
            if (l2 != null)
            {
                carry += l2.Value;
                l2 = l2.Next;
            }

            curretNode.Next = ListNode<int>.Create(carry % 10);
            carry /= 10;
            curretNode = curretNode.Next;
        }

        return startNode.Next;
    }
}