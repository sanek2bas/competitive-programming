namespace Top.Interview._150.Linked_List;

/// <summary>
/// # 146
/// https://leetcode.com/problems/lru-cache/description/
/// Design a data structure that follows the constraints of a
/// Least Recently Used (LRU) cache.
/// Implement the LRUCache class:
/// LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
/// int get(int key) Return the value of the key if the key exists, otherwise return -1.
/// void put(int key, int value) Update the value of the key if the key exists. 
/// Otherwise, add the key-value pair to the cache. 
/// If the number of keys exceeds the capacity from this operation, evict the least recently used key.
/// The functions get and put must each run in O(1) average time complexity.
/// </summary>
public class LruCashe
{
    private readonly int capacity;
    private readonly Dictionary<int, int> values;
    private readonly LinkedList<int> list;
    private readonly Dictionary<int, LinkedListNode<int>> map;

    public LruCashe(int capacity)
    {
        this.capacity = capacity;
        map = new Dictionary<int, LinkedListNode<int>>();
        values = new Dictionary<int, int>();
        list = new LinkedList<int>();
    }

    public int Get(int key)
    {
        if (map.TryGetValue(key, out LinkedListNode<int> node))
        {
            list.Remove(node);
            list.AddFirst(node);
            return values[key];
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        LinkedListNode<int> node;
        if (map.TryGetValue(key, out node))
        {
            values[key] = value;
            list.Remove(node);
            list.AddFirst(node);            
            return;
        }

        if (list.Count == capacity)
        {
            var lruKey = list.Last.Value;
            list.RemoveLast();
            map.Remove(lruKey); 
            values.Remove(lruKey);
        }

        node = list.AddFirst(key);
        map.Add(key, node);
        values.Add(key, value);
    }
}