using Interview.Infrastructure;

namespace Interview.LinkedList
{
    public static class AddTwoNumber
    {
        /// <summary>
        /// You are given two non-empty linked lists representing two non-negative integers. 
        /// The digits are stored in reverse order, and each of their nodes contains a single digit.
        /// Add the two numbers and return the sum as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public static ListNode Execute(ListNode node1, ListNode node2)
        {
            var zeroStartNode = new ListNode();
            var current = zeroStartNode;
            int carry = 0;

            while (node1 != null || node2 != null || carry > 0)
            {
                if(node1 != null)
                {
                    carry += node1.Value;
                    node1 = node1.Next;
                }

                if(node2 != null)
                {
                    carry += node2.Value;
                    node2 = node2.Next;
                }

                current.Next = new ListNode(carry % 10);
                carry /= 10;
                current = current.Next;
            }

            return zeroStartNode.Next;
        }

        public static IEnumerable<(ListNode node1, ListNode node2, int[] answer)> GetTests()
        {
            yield return (
                ListNode.CreateListNode(2, 4, 3),
                ListNode.CreateListNode(5, 6, 4), 
                new int[] {7, 0, 8});
            yield return (
                ListNode.CreateListNode(9, 9, 9, 9, 9, 9, 9),
                ListNode.CreateListNode(9, 9, 9, 9), 
                new int[] {8, 9, 9, 9, 0, 0, 0, 1});
        }

        public static bool CheckResult(ListNode result, int[] answer)
        {
            for(int i = 0; i < answer.Length; i++)
            {
                if(result == null)
                    return false;
                if(result.Value != answer[i])
                    return false;
                result = result.Next;
            }
            return true;
        }
    }
}
