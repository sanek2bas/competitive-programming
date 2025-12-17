namespace Top.Interview._150.Array_String;

public class HIndex
{
    /// <summary>
    /// # 274
    /// https://leetcode.com/problems/h-index/description/
    /// Given an array of integers citations where citations[i] 
    /// is the number of citations a researcher received for their ith paper, 
    /// return the researcher's h-index. According to the definition 
    /// of h-index on Wikipedia: 
    /// The h-index is defined as the maximum value of h such that the 
    /// given researcher has published at least h papers that have 
    /// each been cited at least h times.
    /// </summary>
    public int Execute(int[] citations)
    {
        var n = citations.Length;
        var count = new int[n + 1];
        foreach (var citation in citations)
            count[Math.Min(citation, n)]++;

        var answer = 0;
        for(int i = n; i >= 0; i--)
        {
            answer += count[i];
            if (answer >= i)
                return i;
        }
        return 0;
    }
}