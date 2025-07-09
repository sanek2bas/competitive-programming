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
        foreach (var test in BinarySearch.GetTests())
        {
            var result = BinarySearch.Execute(test.numbers, test.target);
            Console.WriteLine(BinarySearch.CheckResult(result, test.answer));
        }
    }
}