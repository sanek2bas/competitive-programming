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
        foreach (var test in ValidAnagram.GetTests())
        {
            var result = ValidAnagram.Execute(test.s, test.t);
            Console.WriteLine(ValidAnagram.CheckResult(result, test.answer));
        }
    }
}