namespace Top.Interview._150.Backtacking;

public class Permutation
{
    /// <summary>
    /// # 46
    /// https://leetcode.com/problems/permutations/description/
    /// Given an array nums of distinct integers, 
    /// return all the possible permutations.
    /// You can return the answer in any order.
    /// </summary>
    public IList<IList<int>> Execute(int[] nums)
    {
        var result = new List<IList<int>>();
        DFS(nums, new bool[nums.Length], new List<int>(), result);
        return result;
    }

    private void DFS(int[] nums,
                     bool[] used,
                     IList<int> path,
                     IList<IList<int>> result)
    {
        if (nums.Length == path.Count)
        {
            result.Add([.. path]);
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i])
                continue;
            used[i] = true;
            path.Add(nums[i]);
            DFS(nums, used, path, result);
            path.RemoveAt(path.Count - 1);
            used[i] = false;
        }
    }
}