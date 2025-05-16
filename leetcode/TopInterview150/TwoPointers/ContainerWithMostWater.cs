namespace TopInterview150.TwoPointers
{
    public static class ContainerWithMostWater
    {
        /// <summary>
        /// You are given an integer array height of length n. 
        /// There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
        /// Find two lines that together with the x-axis form a container, such that the container contains the most water.
        /// Return the maximum amount of water a container can store.
        /// </summary>
        public static int Execute(int[] height)
        {
            var result = 0;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                var area = (right - left) * Math.Min(height[left], height[right]);
                result = Math.Max(area, result);
                if (height[left] > height[right])
                    right--;
                else
                    left++;
            }
            return result;
        }

        public static IEnumerable<(int[] heights, int answer)> GetTests()
        {
            yield return (
                new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 },
                49);
            yield return (
                new int[] { 1, 1},
                1);
        }

        public static bool CheckResult(int target, int answer)
        {
            return answer == target;
        }
    }
}
