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
            private readonly Queue<int> queue;
            private readonly Dictionary<int, int> dic;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                dic = new Dictionary<int, int>();
                queue = new Queue<int>();
            }

            public int Get(int key)
            {
                if (dic.ContainsKey(key))
                    return dic[key];
                return -1;
            }

            public void Put(int key, int value)
            {
                if (dic.ContainsKey(key))
                {
                    dic[key] = value;
                    return;
                }

                if (queue.Count == capacity)
                {
                    var removeKey = queue.Dequeue();
                    dic.Remove(removeKey);
                }

                dic.Add(key, value);
                queue.Enqueue(key);
            }
        }
    }
}
