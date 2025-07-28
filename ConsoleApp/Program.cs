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
        foreach (var test in FindAllAnagramsInString.GetTests())
        {
            var result = FindAllAnagramsInString.Execute(test.s, test.p);
            Console.WriteLine(FindAllAnagramsInString.CheckResult(result, test.answer));
        }
    }
}