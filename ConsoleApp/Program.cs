using Interview.Dfs_Bfs;
using Interview.DynamicProgramming;
using Interview.HashTable;
using Interview.PrefixSum;
using TopInterview150.BinaryTreeGeneral;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var test in ProductOfArrayExceptSelf.GetTests())
        {
            var result = ProductOfArrayExceptSelf.Execute(test.numbers);
            Console.WriteLine(ProductOfArrayExceptSelf.CheckResult(result, test.answer));
        }
    }
}