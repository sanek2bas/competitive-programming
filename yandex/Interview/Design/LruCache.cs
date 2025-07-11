using System.ComponentModel;
using System.Reflection;

namespace Interview.Design
{
    public static class LruCache
    {
        /// <summary>
        /// Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.
        /// Implement the LRUCache class:
        /// 
        /// RUCache(int capacity) Initialize the LRU cache with positive size capacity.
        /// int get(int key) Return the value of the key if the key exists, otherwise return -1.
        /// void put(int key, int value) Update the value of the key if the key exists.Otherwise, 
        /// add the key-value pair to the cache.
        /// If the number of keys exceeds the capacity from this operation, evict the least recently used key.
        /// The functions get and put must each run in O(1) average time complexity.
        /// </summary>
        public static int?[] Execute(int capacity, string[] commands, IList<int[]> data)
        {
            var result = new int?[commands.Length];
            var cache = new LRUCache(capacity);

            for (int i = 0; i < commands.Length; i++)
            {
                switch(commands[i])
                {
                    case "put":
                        cache.Put(data[i][0], data[i][1]);
                        break;
                    case "get":
                        result[i] = cache.Get(data[i][0]);
                        break;
                }
            }

            return result;
        }

        public static IEnumerable<(int capacity, string[] commands, IList<int[]> data, int?[] answer)> GetTests()
        {
            yield return (
                2,
                new string[] { "put", "put", "get", "put", "get", "put", "get", "get", "get" },
                new List<int[]>
                {
                    new int[] { 1, 1 },
                    new int[] { 2, 2 },
                    new int[] { 1 },
                    new int[] { 3, 3 },
                    new int[] { 2 },
                    new int[] { 4, 4 },
                    new int[] { 1 },
                    new int[] { 3 },
                    new int[] { 4 }
                },
                new int?[] { null, null, 1, null, -1, null, -1, 3, 4 });
            yield return (
                2,
                new string[] { "put", "put","get","put", "get", "put", "get", "get", "get" },
                new List<int[]> 
                {
                    new int[] { 1, 0 },
                    new int[] { 2, 2 },
                    new int[] { 1 },
                    new int[] { 3, 3 },
                    new int[] { 2 },
                    new int[] { 4, 4 },
                    new int[] { 1 },
                    new int[] { 3 },
                    new int[] { 4 }
                },
                new int?[] { null, null, 0, null, -1, null, -1, 3, 4 });
        }

        public static bool CheckResult(int?[] result, int?[] answer)
        {
            return result.SequenceEqual(answer);
        }

        private class LRUCache
        {
            private readonly int capacity;
            private readonly Dictionary<int, Node> dic;
            private Node head;
            private Node tail;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                dic = new Dictionary<int, Node>();
                head = new Node(0, 0);
                tail = new Node(0, 0);
                head.Next = tail;
                tail.Prev = head;
            }

            public int Get(int key)
            {
                if (!dic.TryGetValue(key, out Node node))
                    return -1;
                RemoveNode(node);
                AddToHead(node);
                return node.Value;
            }

            public void Put(int key, int value)
            {
                Node node = null;
                if (dic.TryGetValue(key, out node))
                {
                    node.Value = value;
                    RemoveNode(node);
                    AddToHead(node);
                }
                else
                {
                    if (dic.Count == capacity)
                    {
                        var remNode = RemoveFromTail();
                        dic.Remove(remNode.Key);
                    }
                    node = new Node(key, value);
                    dic.Add(key, node);
                    AddToHead(node);
                }                
            }

            private void AddToHead(Node node)
            {
                node.Prev = head;
                node.Next = head.Next;
                head.Next.Prev = node;
                head.Next = node;
            }

            private void RemoveNode(Node node)
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }

            private Node RemoveFromTail()
            {
                var removeNode = tail.Prev;
                RemoveNode(removeNode);
                return removeNode;
            }

            private class Node
            {
                public int Key { get; init; }
                public int Value { get; set; }
                public Node Prev { get; set; }
                public Node Next { get; set; }

                public Node(int key, int value)
                {
                    Key = key;
                    Value = value; 
                }
            }
        }
    }
}
