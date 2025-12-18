using Top.Interview._150.Binary_Search_Tree;
using Top.Interview._150.Common;

namespace Binary_Search_Tree;

public class MinimumAbsoluteDifferenceTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode? root, int answer)
    {
        var solution = new MinimumAbsoluteDifference();

        var result = solution.Execute(root);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode? root, int answer)> DataSource()
    {
        yield return (
            CreateTreeNode(4, 2, 6, 1, 3),
            1);
        yield return (
            CreateTreeNode(41, 0, 48, null, null, 12, 49),
            1);
        yield return (
            CreateTreeNode(3, 1, 4, null, 2),
            1);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}