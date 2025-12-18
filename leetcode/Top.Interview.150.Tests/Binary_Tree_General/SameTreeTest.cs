using Top.Interview._150.Binary_Tree_General;
using Top.Interview._150.Common;

namespace Binary_Tree_General;

public class SameTreeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode p, TreeNode q, bool answer)
    {
        var solution = new SameTree();

        var result = solution.Execute(p, q);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode root1, TreeNode root2, bool answer)> DataSource()
    {
        yield return (
            CreateTreeNode(1, 2, 3),
            CreateTreeNode(1, 2, 3),
            true);
        yield return (
            CreateTreeNode(1, 2, null),
            CreateTreeNode(1, null, 2),
            false);
        yield return (
            CreateTreeNode(1, 2,1),
            CreateTreeNode(1, 1, 2),
            false);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}