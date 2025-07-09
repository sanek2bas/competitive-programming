using Interview.BinarySearch;
using Interview.Dfs_Bfs;
using Interview.DynamicProgramming;
using Interview.HashTable;
using Interview.PrefixSum;
using TopInterview150.BinaryTreeGeneral;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var test in FindMinimumInRotatedSortedArray.GetTests())
        {
            var result = FindMinimumInRotatedSortedArray.Execute(test.numbers);
            Console.WriteLine(FindMinimumInRotatedSortedArray.CheckResult(result, test.answer));
        }
    }
}