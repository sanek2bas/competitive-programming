namespace Interview.Infrastructure
{
    public class ListNode
    {
        public int Value { get; init; }

        public ListNode? Next { get; set; }

        public ListNode(int value = - 1)
        {
            Value = value;
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

        public static ListNode CreateCycleListNode(int[] numbers, int pos)
        {
            var root = CreateListNode(numbers);
            var lastNode = root;
            while (lastNode.Next != null)
                lastNode = lastNode.Next;

            if(pos >= 0)
            {
                ListNode posNode = root;
                for (int i = 1; i <= pos; i++)
                    posNode = posNode.Next;
                lastNode.Next = posNode;
            }
            
            return root;
        }
    }
}
