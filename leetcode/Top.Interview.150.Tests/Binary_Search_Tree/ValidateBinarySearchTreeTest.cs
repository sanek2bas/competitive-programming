using Top.Interview._150.Binary_Search_Tree;
using Top.Interview._150.Common;

namespace Binary_Search_Tree;

public class ValidateBinarySearchTreeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode? root, bool answer)
    {
        var solution = new ValidateBinarySearchTree();

        var result = solution.Execute(root);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode? root, bool answer)> DataSource()
    {
        yield return (
            CreateTreeNode(2, 1, 3),
            true);
        yield return (
            CreateTreeNode(5, 1, 4, null, null, 3, 6),
            false);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}