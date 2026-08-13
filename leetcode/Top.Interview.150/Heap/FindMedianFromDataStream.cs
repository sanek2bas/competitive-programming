namespace Top.Interview._150.Heap;

public class FindMedianFromDataStream
{
    /// <summary>
    /// # 295
    /// https://leetcode.com/problems/find-median-from-data-stream/description/
    /// The median is the middle value in an ordered integer list. 
    /// If the size of the list is even, there is no middle value, 
    /// and the median is the mean of the two middle values.
    /// For example, for arr = [2,3,4], the median is 3.
    /// For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.
    /// Implement the MedianFinder class:
    /// MedianFinder() initializes the MedianFinder object.
    /// void addNum(int num) adds the integer num from the data stream to the data structure.
    /// double findMedian() returns the median of all elements so far. 
    /// Answers within 10-5 of the actual answer will be accepted.
    /// </summary>
    public IList<double?> Execute(IList<(string key, int num)> commands)
    {
        var result = new List<double?>();
        var medianFinder = new MedianFinder();
        result.Add(null);
        foreach(var command in commands)
        {
            switch(command.key)
            {
                case "addNum":
                    medianFinder.AddNum(command.num);
                    result.Add(null);
                    break;
                
                case "findMedian":
                    var med = medianFinder.FindMedian();
                    result.Add(med);
                    break;
            }
        }
        return result;
    }

    public class MedianFinder
    {
        private PriorityQueue<int, int> maxHeap;
        private PriorityQueue<int, int> minHeap;
        
        public MedianFinder()
        {
            maxHeap = new PriorityQueue<int, int>();
            minHeap = new PriorityQueue<int, int>(
                Comparer<int>.Create((a, b) => b.CompareTo(a)));
        }
    
        public void AddNum(int num)
        {
            maxHeap.Enqueue(num, num);
            minHeap.Enqueue(maxHeap.Peek(), maxHeap.Dequeue());
            if (minHeap.Count > maxHeap.Count + 1) {
                maxHeap.Enqueue(minHeap.Peek(), minHeap.Dequeue());
        }
        }
    
        public double FindMedian()
        {
            return minHeap.Count == maxHeap.Count 
                ? (minHeap.Peek() + maxHeap.Peek()) / 2.0 
                : minHeap.Peek();
        }
    }
}