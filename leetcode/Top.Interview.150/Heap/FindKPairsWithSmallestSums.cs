namespace Top.Interview._150.Heap;

public class FindKPairsWithSmallestSums
{
    /// <summary>
    /// # 373
    /// https://leetcode.com/problems/find-k-pairs-with-smallest-sums/description/
    /// You are given two integer arrays nums1 and nums2 sorted 
    /// in non-decreasing order and an integer k.
    /// Define a pair (u, v) which consists of one element from the first 
    /// array and one element from the second array.
    /// Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) 
    /// with the smallest sums.
    /// </summary>
    public IList<IList<int>> Execute(int[] nums1, int[] nums2, int k)
    {
        var result = new List<IList<int>>();
        
        if (nums1 == null 
            || nums2 == null 
            || nums1.Length == 0 
            || nums2.Length == 0 
            || k <= 0)
            return result;

        var minHeap = new PriorityQueue<(int i, int j), int>();

        int maxRows = Math.Min(nums1.Length, k);
        for (int i = 0; i < maxRows; i++)
            minHeap.Enqueue((i, 0), nums1[i] + nums2[0]);

        while (minHeap.Count > 0 && result.Count < k) 
        {
            var (i, j) = minHeap.Dequeue();            
            result.Add([nums1[i], nums2[j]]);
            if (j + 1 < nums2.Length)
                minHeap.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
        }

        return result;
    }
}