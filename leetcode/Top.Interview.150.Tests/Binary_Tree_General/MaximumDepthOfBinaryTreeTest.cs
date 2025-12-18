using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_General;

namespace Binary_Tree_General;

public class MaximumDepthOfBinaryTreeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode<int?> root, int answer)
    {
        var solution = new MaximumDepthOfBinaryTree();

        var result = solution.Execute(root);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode<int?>? root, int answer)> DataSource()
    {
         yield return (
            TreeNode<int?>.Create(3, 9, 20, null, null, 15, 7),
            3);
        yield return (
            TreeNode<int?>.Create(1, null, 2),
            2);
    }
}