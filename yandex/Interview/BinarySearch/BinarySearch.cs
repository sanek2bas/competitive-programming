namespace Interview.BinarySearch
{
    public static class BinarySearch
    {
        /// <summary>
        /// Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums.
        /// If target exists, then return its index. Otherwise, return -1.
        /// You must write an algorithm with O(log n) runtime complexity.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Execute(int[] numbers, int target)
        {
            int min = 0;
            int max = numbers.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (numbers[mid] == target)
                    return mid;
                if (numbers[mid] > target)
                    max = mid - 1;
                else
                    min = mid + 1;
            }
            return -1;
        }

        public static IEnumerable<(int[] numbers, int target, int answer)> GetTests()
        {
            yield return (new int[] { -1, 0, 3, 5, 9, 12 }, 9, 4);
            yield return (new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1);
        }
    }
}
