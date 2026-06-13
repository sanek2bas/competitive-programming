namespace Top.Interview._150.Array_String;

public class TrappingRainWater
{
    /// <summary>
    /// # 42
    /// https://leetcode.com/problems/trapping-rain-water/description/
    /// Given n non-negative integers representing an elevation map where 
    /// the width of each bar is 1, compute how much water it can trap after raining.
    /// </summary>
    public int Execute(int[] height)
    {
        if (height.Length == 0)
            return 0;

        int ans = 0;
        int l = 0;
        int r = height.Length - 1;
        int maxL = height[l];
        int maxR = height[r];

        while (l < r)
        {
            if (maxL < maxR) 
            {
                ans += maxL - height[l];
                maxL = Math.Max(maxL, height[++l]);
            } else 
            {
                ans += maxR - height[r];
                maxR = Math.Max(maxR, height[--r]);
            }
        }

        return ans;
    }
}