using Interview.Dfs_Bfs;
using Interview.DynamicProgramming;
using Interview.HashTable;
using TopInterview150.BinaryTreeGeneral;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var test in GenerateParentheses.GetTests())
        {
            var result = GenerateParentheses.Execute(test.n);
            Console.WriteLine(GenerateParentheses.CheckResult(result, test.answer));
        }
    }
}