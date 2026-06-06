using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_General;

namespace Binary_Tree_General;

public class LowestCommonAncestorOfBinaryTreeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, TreeNode p, TreeNode q, int answer)
    {
        var solution = new LowestCommonAncestorOfBinaryTree();

        var result = solution.Execute(root, p, q);
        
        await Assert.That(result.Value)
                    .IsEqualTo(answer);
    }

    public IEnumerable<(TreeNode root, TreeNode p, TreeNode q, int answer)> DataSource()
    {
        yield return (
            CreateTreeNode(3, 5, 1, 6, 2, 0, 8, null, null, 7, 4),
            CreateTreeNode(5),
            CreateTreeNode(1),
            3);

        yield return (
            CreateTreeNode(3, 5, 1, 6, 2, 0, 8, null, null, 7, 4),
            CreateTreeNode(5),
            CreateTreeNode(4),
            5);
        
        yield return (
            CreateTreeNode(1, 2),
            CreateTreeNode(1),
            CreateTreeNode(2),
            1);
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }

    private int?[] ConvertToArray(TreeNode node)
    {
        if (node == null)
            return [];
        return node.ToArray();
    }
}