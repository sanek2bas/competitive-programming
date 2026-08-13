namespace Top.Interview._150.Array_String;

public class Candy
{
    /// <summary>
    /// # 135
    /// https://leetcode.com/problems/candy/description/
    /// There are n children standing in a line. Each child is assigned 
    /// a rating value given in the integer array ratings.
    /// You are giving candies to these children subjected to the following requirements:
    /// Each child must have at least one candy.
    /// Children with a higher rating get more candies than their neighbors.
    /// Return the minimum number of candies you need to have to distribute
    /// the candies to the children.
    /// </summary>
    public int Execute(int[] ratings)
    {
        int n = ratings.Length;

        int result = 0;
        int[] l = new int[n];
        int[] r = new int[n];
        Array.Fill(l, 1);
        Array.Fill(r, 1);

        for (int i = 1; i < n; ++i)
        {
            if (ratings[i] > ratings[i - 1])
                l[i] = l[i - 1] + 1;
        }

        for (int i = n - 2; i >= 0; --i)
        {
            if (ratings[i] > ratings[i + 1])
                r[i] = r[i + 1] + 1;
        }

        for (int i = 0; i < n; ++i)
            result += Math.Max(l[i], r[i]);

        return result;
    }
}