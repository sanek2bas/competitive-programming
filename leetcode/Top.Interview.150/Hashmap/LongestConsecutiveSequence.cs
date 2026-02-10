namespace Top.Interview._150.Hashmap;

public class LongestConsecutiveSequence
{
    /// <summary>
    /// # 128
    /// https://leetcode.com/problems/longest-consecutive-sequence/description/
    /// Given an unsorted array of integers nums, return the length
    /// of the longest consecutive elements sequence.
    /// You must write an algorithm that runs in O(n) time.
    /// </summary>
    public int Execute(int[] nums)
    {
        var hashSet = new HashSet<int>(nums);
        int longSeq = 0;
        foreach (int num in hashSet)
        {
            if (hashSet.Contains(num - 1))
                continue;
            int curNum = num;
            int curSeq = 1;
            while(hashSet.Contains(curNum+1))
            {
                curNum++;
                curSeq++;
            }
            longSeq = Math.Max(longSeq, curSeq);
        }
        return longSeq;
    }
}