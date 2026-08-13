using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_BFS;

namespace Binary_Tree_BFS;

public class AverageOfLevelsInBinaryTreeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, IList<double> answer)
    {
        var solution = new AverageOfLevelsInBinaryTree();

        var result = solution.Execute(root);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(TreeNode? root, IList<double> answer)> DataSource()
    {
        yield return (
            CreateTreeNode(3, 9, 20, null, null, 15, 7),
            [3.00000, 14.50000, 11.00000]);
        
        yield return (
            CreateTreeNode(3, 9, 20, 15, 7),
            [3.00000, 14.50000, 11.00000]);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}