using Infrastructure;

namespace TopInterview150.LinkedList
{
    public static class CopyListWithRandomPointer
    {
        /// <summary>
        /// A linked list of length n is given such that each node contains an additional random pointer,
        /// which could point to any node in the list, or null.
        /// Construct a deep copy of the list.The deep copy should consist of exactly n brand new nodes, 
        /// where each new node has its value set to the value of its corresponding original node.
        /// Both the next and random pointer of the new nodes should point to new nodes in the copied list such 
        /// that the pointers in the original list and copied list represent the same list state.
        /// None of the pointers in the new list should point to nodes in the original list.
        /// For example, if there are two nodes X and Y in the original list, where X.random --> Y, 
        /// then for the corresponding two nodes x and y in the copied list, x.random --> y.
        /// Return the head of the copied linked list.
        /// The linked list is represented in the input/output as a list of n nodes.Each node is represented as a pair of[val, random_index] where:
        /// val: an integer representing Node.val
        /// random_index: the index of the node (range from 0 to n-1) that the random pointer points to, or null if it does not point to any node.
        /// Your code will only be given the head of the original linked list.
        /// </summary>
        public static ListNodeWithRandom Execute(ListNodeWithRandom head)
        {
            return Copy(head, new Dictionary<ListNodeWithRandom, ListNodeWithRandom>());
        }

        private static ListNodeWithRandom Copy(ListNodeWithRandom head, Dictionary<ListNodeWithRandom, ListNodeWithRandom> dic)
        {
            if (head == null)
                return null;
            if (dic.ContainsKey(head))
                return dic[head];

            var newNode = new ListNodeWithRandom(head.Value);
            dic.Add(head, newNode);
            newNode.Next = Copy(head.Next, dic);
            newNode.Random = Copy(head.Random, dic);
            return newNode;
        }

        public static IEnumerable<(ListNodeWithRandom head, ListNodeWithRandom answer)> GetTests()
        {
            var node1 = ListNodeWithRandom.Map((7, -1), (13, 0), (11, 4), (10, 2), (1, 0));
            yield return (node1, node1);
            var node2 = ListNodeWithRandom.Map((1, 1), (2, 1));
            yield return (node2, node2);
            var node3 = ListNodeWithRandom.Map((3, -1), (3, 0), (3, -1));
            yield return (node3, node3);
        }

        public static bool CheckResult(ListNodeWithRandom result, ListNodeWithRandom answer)
        {
            if (ReferenceEquals(result, answer))
                return false;

            while (result != null && answer != null)
            {
                if(result.Value != answer.Value)
                    return false;
                if (result.Next?.Value != answer.Next?.Value)
                    return false;
                if(result.Random?.Value != result.Random?.Value)
                    return false;
                result = result.Next;
                answer = answer.Next;
            }

            return result == null && answer == null;
        }
    }
}
