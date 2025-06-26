using Interview.Dfs_Bfs;
using Interview.HashTable;
using TopInterview150.BinaryTreeGeneral;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var test in PopulationNextRightPointersInEachNode2.GetTests())
        {
            PopulationNextRightPointersInEachNode2.Execute(test.root);
            Console.WriteLine(PopulationNextRightPointersInEachNode2.CheckResult(test.root, test.answer));
        }
    }
}