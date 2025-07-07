using Interview.Dfs_Bfs;
using Interview.DynamicProgramming;
using Interview.HashTable;
using TopInterview150.BinaryTreeGeneral;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var test in InterestingJourney.GetTests())
        {
            var result = InterestingJourney.Execute(test.cites, test.distance, test.start, test.end);
            Console.WriteLine(InterestingJourney.CheckResult(result, test.answer));
        }
    }
}