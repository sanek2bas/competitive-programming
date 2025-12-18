using Top.Interview._150.Binary_Tree_General;
using Top.Interview._150.Common;

namespace Binary_Tree_General;

public class ConstructBinaryTreeFromPreorderAndInorderTraversalTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] preorder, int[] inorder, TreeNode answer)
    {
        var solution = new ConstructBinaryTreeFromPreorderAndInorderTraversal();

        var result = solution.Execute(preorder, inorder);
        
        await Assert.That(new SameTree().Execute(result, answer)).IsTrue();
    }

    public IEnumerable<(int[] preorder, int[] inorder, TreeNode answer)> DataSource()
    {
        yield return (
            new int[] { 3, 9, 20, 15, 7 },
            new int[] { 9, 3, 15, 20, 7 },
            CreateTreeNode(3, 9, 20, null, null, 15, 7));
        yield return (
            new int[] { -1 },
            new int[] { -1 },
            CreateTreeNode(-1));
    }

    private TreeNode CreateTreeNode(params int?[] numbers)
    {
        return TreeNode.Create(numbers);
    }
}