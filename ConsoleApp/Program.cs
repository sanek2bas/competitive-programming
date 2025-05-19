using TopInterview150.BinaryTreeGeneral;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var test in ConstructBinaryTreeFromInorderAndPostorderTraversal.GetTests())
        {
            var result = ConstructBinaryTreeFromInorderAndPostorderTraversal.Execute(test.inorder, test.postorder);
            Console.WriteLine(ConstructBinaryTreeFromInorderAndPostorderTraversal.CheckResult(result, test.answer));
        }
    }
}