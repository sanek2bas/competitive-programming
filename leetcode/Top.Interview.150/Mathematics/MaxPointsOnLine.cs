namespace Top.Interview._150.Mathematics;

public class MaxPointsOnLine
{
    /// <summary>
    /// # 149
    /// https://leetcode.com/problems/max-points-on-a-line/description/
    /// Given an array of points where points[i] = [xi, yi] represents a point 
    /// on the X-Y plane, return the maximum number of points that lie 
    /// on the same straight line.
    /// </summary>
    public int Execute(int[][] points)
    {
        if (points.Length <= 2) 
            return points.Length;
        
        int maxPoints = 1;
        
        for (int i = 0; i < points.Length; i++) 
        {
            var slopeCount = new Dictionary<string, int>();
            int duplicate = 0;
            int currentMax = 0;
            
            for (int j = i + 1; j < points.Length; j++) 
            {
                int dx = points[j][0] - points[i][0];
                int dy = points[j][1] - points[i][1];
                
                if (dx == 0 && dy == 0) 
                {
                    duplicate++;
                    continue;
                }
                
                int gcd = GCD(dx, dy);
                dx /= gcd;
                dy /= gcd;
                
                if (dx < 0 || (dx == 0 && dy < 0)) 
                {
                    dx = -dx;
                    dy = -dy;
                }
                
                string slopeKey = $"{dx},{dy}";
                
                if (!slopeCount.ContainsKey(slopeKey)) 
                {
                    slopeCount[slopeKey] = 0;
                }
                slopeCount[slopeKey]++;
                
                currentMax = Math.Max(currentMax, slopeCount[slopeKey]);
            }
            
            maxPoints = Math.Max(maxPoints, currentMax + duplicate + 1);
        }
        
        return maxPoints;
    }
    
    private int GCD(int a, int b) 
    {
        if (b == 0) 
            return Math.Abs(a);
        return GCD(Math.Abs(b), Math.Abs(a % b));
    }
}