namespace Top.Interview._150.Backtracking;

public class CombinationSum
{
    /// <summary>
    /// # 39
    /// https://leetcode.com/problems/combination-sum/description/
    /// Given an array of distinct integers candidates and a target integer, 
    /// return a list of all unique combinations of candidates where the 
    /// chosen numbers sum to target. You may return the combinations in any order.
    /// The same number may be chosen from candidates an unlimited number of times. 
    /// Two combinations are unique if the frequency of at least one of the chosen
    /// numbers is different. The test cases are generated such that the number 
    /// of unique combinations that sum up to target is less than 
    /// 150 combinations for the given input.
    /// </summary>
    public IList<IList<int>> Execute(int[] candidates, int target)
    {
        var results = new List<IList<int>>();
        var r = new List<int>();
        Array.Sort(candidates);
        DFS(0, target, candidates, new List<int>(), results);
        return results;
    }

    private void DFS(
        int idx, 
        int target, 
        IList<int> candidates, 
        IList<int> res,
        IList<IList<int>> results)
    {
        if (target == 0)
        {
            results.Add(res.ToList());
            return;
        }

        if (idx >= candidates.Count
            || target < candidates[idx])
            return;
        
        DFS(idx + 1, target, candidates, res, results);
        res.Add(candidates[idx]);
        DFS(idx, target - candidates[idx], candidates, res, results);
        res.RemoveAt(res.Count - 1);
    }
}