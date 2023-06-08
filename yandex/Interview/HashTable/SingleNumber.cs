using Interview.LinkedList;

namespace Interview.HashTable
{
    public static class SingleNumber
    {
        /// <summary>
        /// Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
        /// You must implement a solution with a linear runtime complexity and use only constant extra space.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int Execute(int[] numbers)
        {
            int result = 0;
            foreach (int number in numbers)
                result ^= number;
            return result;
        }

        public static IEnumerable<(int[] numbers, int answer)> GetTests()
        {
            yield return (new int[] { 2, 2, 1}, 1);
            yield return (new int[] { 4, 1, 2, 1, 2 }, 4);
            yield return (new int[] { 1}, 1);
        }
    }
}
