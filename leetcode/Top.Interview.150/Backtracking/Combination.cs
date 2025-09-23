namespace Top.Interview._150.Backtracking;

public class Combination
{
    /// <summary>
    /// # 77
    /// https://leetcode.com/problems/combinations/description/
    /// Given two integers n and k, return all possible combinations 
    /// of k numbers chosen from the range [1, n].
    /// You may return the answer in any order.
    /// </summary>
    public IList<IList<int>> Execute(int n, int k)
    {
        var result = new List<IList<int>>();
        DFS(n, k, 1, new List<int>(), result);
        return result;
    }

    private void DFS(int n, int k, int s, List<int> path, List<IList<int>> result)
    {
        if (path.Count == k)
        {
            result.Add(path.ToList());
            return;
        }

        for (int i = s; i <= n; ++i)
        {
            path.Add(i);
            DFS(n, k, i + 1, path, result);
            path.RemoveAt(path.Count - 1);
        }
    }
}
