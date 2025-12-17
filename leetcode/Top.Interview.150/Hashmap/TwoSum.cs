namespace Top.Interview._150.Hashmap;

public class TwoSum
{
    /// <summary>
    /// # 1
    /// https://leetcode.com/problems/two-sum/description/
    /// Given an array of integers nums and an integer target, 
    /// return indices of the two numbers such that they add up to target.
    /// You may assume that each input would have exactly one solution, 
    /// and you may not use the same element twice.
    /// You can return the answer in any order.
    /// </summary>
    public int[] Execute(int[] nums, int target)
    {
        var dic = new Dictionary<int, int>();
        var result = new int[2];

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (dic.ContainsKey(target - num))
            {
                result[0] = dic[target - num];
                result[1] = i;
                break;
            }
            if (!dic.ContainsKey(num))
                dic.Add(num, i);
        }

        return result;
    }
}