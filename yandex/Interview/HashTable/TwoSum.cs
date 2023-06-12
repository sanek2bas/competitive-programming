namespace Interview.HashTable
{
    public static class TwoSum
    {
        /// <summary>
        /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can return the answer in any order.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] Execute(int[] nums, int target)
        {
            var result = new int[2];
            var dic = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if(dic.ContainsKey(target - num))
                {
                    result[0] = dic[target - num];
                    result[1] = i;
                    break;
                }
                dic.Add(num, i);
            }

            return result;
        }

        public static IEnumerable<(int[] numbers, int target, int[] answer)> GetTests()
        {
            yield return (new int[] {2, 7, 11, 15}, 9, new int[] {0, 1});
            yield return (new int[] {3, 2, 4}, 6, new int[] {1, 2});
            yield return (new int[] {3, 3}, 6, new int[] {0, 1});
        }

        public static bool CheckResult(int[] result, int[] answer)
        {
            return result[0] == answer[0] 
                && result[1] == answer[1];
        }
    }
}
