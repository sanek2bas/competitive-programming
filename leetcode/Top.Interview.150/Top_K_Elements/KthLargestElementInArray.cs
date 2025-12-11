namespace Top.Interview._150.Top_K_Elements;

public class KthLargestElementInArray
{
    /// <summary>
    /// # 215
    /// https://leetcode.com/problems/kth-largest-element-in-an-array/description/
    /// Given an integer array nums and an integer k, 
    /// return the kth largest element in the array.
    /// Note that it is the kth largest element in the sorted order, 
    /// not the kth distinct element.
    /// Can you solve it without sorting?
    /// </summary>
    public int Execute(int[] nums, int k)
    {
        var queue = new PriorityQueue<int, int>();
        foreach (int num in nums)
            queue.Enqueue(num, num);
        while (queue.Count > k)
            queue.Dequeue();
        return queue.Peek();
    }
}