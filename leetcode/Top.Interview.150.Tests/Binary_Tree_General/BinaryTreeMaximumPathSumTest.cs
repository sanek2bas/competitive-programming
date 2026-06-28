using Top.Interview._150.Binary_Tree_General;
using Top.Interview._150.Common;

namespace Binary_Tree_General;

public class BinaryTreeMaximumPathSumTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, int answer)
    {
        var solution = new BinaryTreeMaximumPathSum();

        var result = solution.Execute(root);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode root, int answer)> DataSource()
    {
        yield return (
            CreateTreeNode(1, 2, 3),
            6);

        yield return (
            CreateTreeNode(-10, 9, 20, null, null, 15, 7),
            42);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}