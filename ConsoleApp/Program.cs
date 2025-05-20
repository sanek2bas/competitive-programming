using Interview.Dfs_Bfs;
using Interview.HashTable;
using TopInterview150.BinaryTreeGeneral;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var test in FlattenBinaryTreeToLinkedList.GetTests())
        {
            FlattenBinaryTreeToLinkedList.Execute(test.root);
            Console.WriteLine(FlattenBinaryTreeToLinkedList.CheckResult(test.root, test.answer));
        }
    }
}