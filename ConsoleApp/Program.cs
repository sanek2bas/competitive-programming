using Interview.Dfs_Bfs;
using Interview.DynamicProgramming;
using Interview.HashTable;
using Interview.PrefixSum;
using TopInterview150.BinaryTreeGeneral;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var test in MinimumSizeSubarraySum.GetTests())
        {
            var result = MinimumSizeSubarraySum.Execute(test.target, test.numbers);
            Console.WriteLine(MinimumSizeSubarraySum.CheckResult(result, test.answer));
        }
    }
}