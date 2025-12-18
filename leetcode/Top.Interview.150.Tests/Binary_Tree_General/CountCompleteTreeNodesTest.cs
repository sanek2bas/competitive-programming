using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_General;

namespace Binary_Tree_General;

public class CountCompleteTreeNodesTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, int answer)
    {
        var solution = new CountCompleteTreeNodes();

        var result = solution.Execute(root);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode root, int answer)> DataSource()
    {
        yield return (CreateTreeNode(1, 2, 3, 4, 5, 6), 6);
        yield return (CreateTreeNode(), 0);
        yield return (CreateTreeNode(1), 1);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}