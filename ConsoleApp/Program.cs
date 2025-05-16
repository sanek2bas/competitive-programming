using TopInterview150.BinaryTreeGeneral;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var test in ConstructBinaryTreeFromPreorderAndInorderTraversal.GetTests())
        {
            var result = ConstructBinaryTreeFromPreorderAndInorderTraversal.Execute(test.preorder, test.inorder);
            Console.WriteLine(ConstructBinaryTreeFromPreorderAndInorderTraversal.CheckResult(result, test.answer));
        }
    }
}