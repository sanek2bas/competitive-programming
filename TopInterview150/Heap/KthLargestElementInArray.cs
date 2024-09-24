namespace TopInterview150.Heap
{
    public static class KthLargestElementInArray
    {
        /// <summary
        /// Given an integer array nums and an integer k, return the kth largest element in the array.
        /// Note that it is the kth largest element in the sorted order, not the kth distinct element.
        /// Can you solve it without sorting?
        /// </summary>
        public static int Execute(int[] nums, int k)
        {
            var queue = new PriorityQueue<int, int>();
            foreach (int num in nums)
                queue.Enqueue(num, num);
            while (queue.Count > k)
                queue.Dequeue();
            return queue.Peek();
        }

        public static IEnumerable<(int[] nums, int k, int answer)> GetTests()
        {
            yield return (new int[] { 3, 2, 1, 5, 6, 4 }, 2, 5);
            yield return (new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}
