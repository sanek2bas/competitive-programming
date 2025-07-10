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
                        result[i] = null;
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
        }

        public static bool CheckResult(int?[] result, int?[] answer)
        {
            return result.SequenceEqual(answer);
        }

        private class LRUCache
        {
            private readonly int capacity;
            private readonly Dictionary<int, Node> dic;
            private Node linkedList;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                dic = new Dictionary<int, Node>();
            }

            public int Get(int key)
            {
                if (!dic.TryGetValue(key, out Node node))
                    return -1;
                //Remove(node);
                //AddFirst(node);
                return node.Value;
            }

            public void Put(int key, int value)
            {
                Node node = null;
                if (dic.TryGetValue(key, out node))
                {
                    node.Value = value;
                    Remove(node);
                }
                else
                {
                    if (dic.Count == capacity)
                    {
                        var remNode = RemoveFirst();
                        dic.Remove(remNode.Value);
                    }
                    else
                    {
                        node = new Node(key, value);
                        dic.Add(key, node);
                    }
                }
                AddFirst(node);
            }

            private void AddFirst(Node node)
            {
                var tmp = linkedList;
                linkedList = node;
                linkedList.Next = tmp;
                if (tmp != null)
                    tmp.Prev = linkedList;

            }

            private void Remove(Node node)
            {
                var left = node.Prev;
                var right = node.Next;
                if (left != null)
                    left.Next = right;
                if (right != null)
                    right.Prev = left;
                node.Prev = null;
                node.Next = null;
            }

            private Node RemoveFirst()
            {
                var tmp = linkedList.Next;
                var node = linkedList;
                linkedList = tmp;
                linkedList.Prev = null;
                node.Next = null;
                node.Prev = null;
                return node;                
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
