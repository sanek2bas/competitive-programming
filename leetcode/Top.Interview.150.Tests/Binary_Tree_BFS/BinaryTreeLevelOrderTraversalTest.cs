using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_BFS;

namespace Binary_Tree_BFS;

public class BinaryTreeLevelOrderTraversalTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, IList<IList<int>> answer)
    {
        var solution = new BinaryTreeLevelOrderTraversal();

        var result = solution.Execute(root);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(TreeNode? root, IList<IList<int>> answer)> DataSource()
    {
        yield return (
            CreateTreeNode(3, 9, 20, null, null, 15, 7),
            [[3], [9,20], [15,7]]);
        
        yield return (
            CreateTreeNode(1),
            [[1]]);
        
        yield return (
            CreateTreeNode(),
            []);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}