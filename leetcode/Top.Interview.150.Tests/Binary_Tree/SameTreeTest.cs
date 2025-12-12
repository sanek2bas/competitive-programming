using Top.Interview._150.Binary_Tree;

namespace Binary_Tree;

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

    public IEnumerable<(TreeNode? root1, TreeNode? root2, bool answer)> DataSource()
    {
        yield return (
            TreeNode.Map(1, 2, 3),
            TreeNode.Map(1, 2, 3),
            true);
        yield return (
            TreeNode.Map(1, 2, null),
            TreeNode.Map(1, null, 2),
            false);
        yield return (
            TreeNode.Map(1, 2, 1),
            TreeNode.Map(1, 1, 2),
            false);
    }
}