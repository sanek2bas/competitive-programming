using Top.Interview._150.Binary_Search_Tree;
using Top.Interview._150.Common;

namespace Binary_Search_Tree;

public class KthSmallestElementInBSTTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode? root, int k, int answer)
    {
        var solution = new KthSmallestElementInBST();

        var result = solution.Execute(root, k);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode? root, int k, int answer)> DataSource()
    {
        yield return (
            CreateTreeNode(3, 1, 4, null, 2),
            1,
            1);
        yield return (
            CreateTreeNode(5, 3, 6, 2, 4, null, null, 1),
            3,
            3);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}