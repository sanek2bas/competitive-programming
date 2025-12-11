using Top.Interview._150.Binary_Tree;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace Binary_Tree;

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
            TreeNode.Map(4, 2, 6, 1, 3),
            1);
        yield return (
            TreeNode.Map(41, 0, 48, null, null, 12, 49),
            1);
        yield return (
            TreeNode.Map(3, 1, 4, null, 2),
            1);
    }
}