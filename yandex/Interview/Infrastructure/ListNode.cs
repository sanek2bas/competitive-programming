namespace Interview.Infrastructure
{
    public class ListNode
    {
        public int Value { get; init; }

        public ListNode? Next { get; set; }

        public ListNode(int value = -1, ListNode? next = null)
        {
            Value = value;
            Next = next;
        }

        public static ListNode CreateListNode(params int[] numbers)
        {
            var startNode = new ListNode();
            var nextNode = startNode;
            foreach (int number in numbers)
            {
                nextNode.Next = new ListNode(number);
                nextNode = nextNode.Next;
            }
            return startNode.Next;
        }
    }
}
