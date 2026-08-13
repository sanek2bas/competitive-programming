namespace Top.Interview._150.Sliding_Window;

public class MinimumWindowSubstring
{
    /// <summary>
    /// # 76
    /// https://leetcode.com/problems/minimum-window-substring/description/
    /// Given two strings s and t of lengths m and n respectively, return 
    /// the minimum window substring of s such that every character 
    /// in t (including duplicates) is included in the window. 
    /// If there is no such substring, return the empty string "".
    /// The testcases will be generated such that the answer is unique.
    /// </summary>
    public string Execute(string s, string t)
    {
        int[] targetFreq = new int[128];
        int[] windowFreq = new int[128];
        
        foreach (char ch in t.ToCharArray())
            targetFreq[ch]++;

        int sourceLen = s.Length;
        int targetLen = t.Length;
        
        int minWindowStart = -1;
        int minWindowLen = sourceLen + 1; 
        int validCharCount = 0;
    
        int left = 0;
        for (int right = 0; right < sourceLen; right++)
        {
            char rightChar = s[right];
            windowFreq[rightChar]++;
        
            if (windowFreq[rightChar] <= targetFreq[rightChar])
                validCharCount++;
        
            while (validCharCount == targetLen)
            {
                if (right - left + 1 < minWindowLen)
                {
                    minWindowLen = right - left + 1;
                    minWindowStart = left;
                }
            
                char leftChar = s[left];
            
                if (windowFreq[leftChar] <= targetFreq[leftChar])
                    validCharCount--;
            
                windowFreq[leftChar]--;
                left++;
            }
        }
    
        return minWindowStart < 0 
            ? "" 
            : s.Substring(minWindowStart, minWindowLen);
    }
}