using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_BFS;

namespace Binary_Tree_BFS;

public class BinaryTreeRightSideViewTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, IList<int> answer)
    {
        var solution = new BinaryTreeRightSideView();

        var result = solution.Execute(root);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(TreeNode? root, IList<int> answer)> DataSource()
    {
        yield return (
            CreateTreeNode(1, 2, 3, null, 5, null, 4),
            [1, 3, 4]);
        
        yield return (
            CreateTreeNode(1, null, 3),
            [1, 3]);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}