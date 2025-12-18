using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_General;

namespace Binary_Tree_General;

public class MaximumDepthOfBinaryTreeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, int answer)
    {
        var solution = new MaximumDepthOfBinaryTree();

        var result = solution.Execute(root);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode root, int answer)> DataSource()
    {
         yield return (
            CreateTreeNode(3, 9, 20, null, null, 15, 7),
            3);
        yield return (
            CreateTreeNode(1, null, 2),
            2);
    }

    private TreeNode CreateTreeNode(params int?[] numbers)
    {
        return TreeNode.Create(numbers);
    }
}