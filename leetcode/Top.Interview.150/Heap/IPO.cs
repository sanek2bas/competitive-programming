namespace Top.Interview._150.Heap;

public class IPO
{
    /// <summary>
    /// # 502
    /// https://leetcode.com/problems/ipo/description/
    /// Suppose LeetCode will start its IPO soon. In order to sell a good 
    /// price of its shares to Venture Capital, LeetCode would like to work 
    /// on some projects to increase its capital before the IPO. Since it has 
    /// limited resources, it can only finish at most k distinct projects 
    /// before the IPO. Help LeetCode design the best way to maximize its 
    /// total capital after finishing at most k distinct projects.
    /// You are given n projects where the ith project has a pure profit 
    /// profits[i] and a minimum capital of capital[i] is needed to start it.
    /// Initially, you have w capital. When you finish a project, you will 
    /// obtain its pure profit and the profit will be added to your total capital.
    /// Pick a list of at most k distinct projects from given projects to 
    /// maximize your final capital, and return the final maximized capital.
    /// The answer is guaranteed to fit in a 32-bit signed integer.
    /// </summary>
    public int Execute(int k, int w, int[] profits, int[] capital)
    {
        var minHeap = 
            new PriorityQueue<(int capital, int profit), int>();
        var maxHeap = 
            new PriorityQueue<int,int>(Comparer<int>.Create((a,b) => b.CompareTo(a)));
        
        for(int i = 0; i < profits.Length; i++)
            minHeap.Enqueue((capital[i],profits[i]),capital[i]);
        int currentCapital = w;
        for(int i = 0; i < k; i++)
        {
            while(minHeap.Count > 0 && minHeap.Peek().capital <= currentCapital)
            {
                var project = minHeap.Dequeue();
                maxHeap.Enqueue(project.profit, project.profit);
            }

            if(maxHeap.Count == 0)
                break;
                
            currentCapital += maxHeap.Dequeue();
        }
        return currentCapital;
    }
}