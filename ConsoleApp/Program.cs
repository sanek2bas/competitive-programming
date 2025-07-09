using Interview.BinarySearch;
using Interview.Design;
using Interview.Dfs_Bfs;
using Interview.DynamicProgramming;
using Interview.HashTable;
using Interview.PrefixSum;
using TopInterview150.BinaryTreeGeneral;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var test in LruCache.GetTests())
        {
            var result = LruCache.Execute(test.capacity, test.commands, test.data);
            Console.WriteLine(LruCache.CheckResult(result, test.answer));
        }
    }
}