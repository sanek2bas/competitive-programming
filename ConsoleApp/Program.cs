using Interview.Dfs_Bfs;
using Interview.HashTable;
using TopInterview150.BinaryTreeGeneral;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var test in PopulatinNextRightPointersInEachNode2.GetTests())
        {
            PopulatinNextRightPointersInEachNode2.Execute(test.root);
            Console.WriteLine(PopulatinNextRightPointersInEachNode2.CheckResult(test.root, test.answer));
        }
    }
}