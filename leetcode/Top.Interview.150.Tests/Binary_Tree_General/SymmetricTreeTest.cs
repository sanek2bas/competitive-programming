using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_General;

namespace Binary_Tree_General;

public class SymmetricTreeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, bool answer)
    {
        var solution = new SymmetricTree();

        var result = solution.Execute(root);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode root, bool answer)> DataSource()
    {
        yield return (
            CreateTreeNode(1, 2, 2, 3, 4, 4, 3), 
            true);
        yield return (
            CreateTreeNode(1, 2, 2, null, 3, null, 3), 
            false);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}