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
    private readonly Dictionary<LinkedListNode<int>, int> reverseDic;
    private readonly Dictionary<int, LinkedListNode<int>> dic;
    private readonly LinkedList<LinkedListNode<int>> list;

    public LruCashe(int capacity)
    {
        this.capacity = capacity;
        reverseDic = new Dictionary<LinkedListNode<int>, int>();
        dic = new Dictionary<int, LinkedListNode<int>>();
        list = new LinkedList<LinkedListNode<int>>();
    }

    public int Get(int key)
    {
        if (dic.TryGetValue(key, out var node))
        {
            list.Remove(node);
            list.AddFirst(node);
            return node.Value;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        LinkedListNode<int> node;
        if (dic.TryGetValue(key, out node))
        {
            node.Value = value;
            list.Remove(node);
            list.AddFirst(node);            
            return;
        }

        if (dic.Count >= capacity)
        {
            node = list.Last();
            var idx = reverseDic[node];
            reverseDic.Remove(node);
            dic.Remove(idx);
            list.Remove(node);
        }

        node = new LinkedListNode<int>(value);
        dic.Add(key, node);
        reverseDic.Add(node, key);
        list.AddFirst(node);
    }
}