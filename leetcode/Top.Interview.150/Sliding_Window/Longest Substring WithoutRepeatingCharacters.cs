namespace Top.Interview._150.Sliding_Window;

public class WithoutRepeatingCharacters
{
    /// <summary>
    /// # 3
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
    /// Given a string s, find the length of the longest substring 
    /// without duplicate characters.
    /// </summary>
    public int Execute(string s)
    {
        HashSet<char> repeated = new HashSet<char>();
        int max = 0;
        int curr = 0;
        int left = 0;
        int right = 0;

        while(right < s.Length)
        {
            var nextChar = s[right];

            while(repeated.Contains(nextChar))
            {
                repeated.Remove(s[left]);
                left++;
                curr--;
            }

            repeated.Add(nextChar);
            curr++;
            max = Math.Max(max, curr);
            right++;
        }
        
        return max;
    }
}