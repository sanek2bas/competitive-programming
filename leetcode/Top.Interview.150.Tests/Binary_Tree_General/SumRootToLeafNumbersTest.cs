using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_General;

namespace Binary_Tree_General;

public class SumRootToLeafNumbersTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, int answer)
    {
        var solution = new SumRootToLeafNumbers();

        var result = solution.Execute(root);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode root, int answer)> DataSource()
    {
        yield return (
            CreateTreeNode(1, 2, 3),
            25);

        yield return (
            CreateTreeNode(4, 9, 0, 5, 1),
            1026);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}