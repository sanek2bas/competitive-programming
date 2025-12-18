using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_General;

namespace Binary_Tree_General;

public class PathSumTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, int targetSum, bool answer)
    {
        var solution = new PathSum();

        var result = solution.Execute(root, targetSum);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode root, int targetSum, bool answer)> DataSource()
    {
        yield return (
            CreateTreeNode(5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1), 
            22, 
            true);
        yield return (
            CreateTreeNode(1, 2, 3),
            5, 
            false);
        yield return (
            CreateTreeNode(), 
            0, 
            false);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}