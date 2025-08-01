﻿namespace Interview.BinarySearch
{
    public static class BinarySearch
    {
        /// <summary>
        /// Given an array of integers nums which is sorted in ascending order, 
        /// and an integer target, write a function to search target in nums.
        /// If target exists, then return its index. Otherwise, return -1.
        /// You must write an algorithm with O(log n) runtime complexity.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Execute(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left <= right) 
            {
                int mid = (left + right) / 2;
                if (numbers[mid] == target)
                    return mid;
                if (numbers[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            
            return -1;
        }

        public static IEnumerable<(int[] numbers, int target, int answer)> GetTests()
        {
            yield return (
                new int[] { -1, 0, 3, 5, 9, 12 }, 
                9, 
                4);
            yield return (
                new int[] { -1, 0, 3, 5, 9, 12 }, 
                2, 
                -1);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}
