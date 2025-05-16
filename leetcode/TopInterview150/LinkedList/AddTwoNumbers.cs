using Infrastructure;

namespace TopInterview150.LinkedList
{
    public static class AddTwoNumbers
    {
        /// <summary>
        /// You are given two non-empty linked lists representing two non-negative integers. 
        /// The digits are stored in reverse order, and each of their nodes contains a single digit. 
        /// Add the two numbers and return the sum as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// </summary>
        public static ListNode Execute(ListNode l1, ListNode l2)
        {
            var startNode = new ListNode();
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

                curretNode.Next = new ListNode(carry % 10);
                carry /= 10;
                curretNode = curretNode.Next;
            }

            return startNode.Next;
        }

        public static IEnumerable<(ListNode node1, ListNode node2, int[] answer)> GetTests()
        {
            yield return (
               ListNode.Map(2, 4, 3),
               ListNode.Map(5, 6, 4),
               new int[] { 7, 0, 8 });
            yield return (
                ListNode.Map(9, 9, 9, 9, 9, 9, 9),
                ListNode.Map(9, 9, 9, 9),
                new int[] { 8, 9, 9, 9, 0, 0, 0, 1 });
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
