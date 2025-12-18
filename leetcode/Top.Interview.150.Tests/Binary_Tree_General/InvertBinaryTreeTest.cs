using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_General;

namespace Binary_Tree_General;

public class InvertBinaryTreeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, int[] answer)
    {
        var solution = new InvertBinaryTree();

        var result = solution.Execute(root);
        
        await Assert.That(ConvertToArray(result)).IsEquivalentTo(answer);
    }

    public IEnumerable<(TreeNode root, int[] answer)> DataSource()
    {
        yield return (
            CreateTreeNode(4, 2, 7, 1, 3, 6, 9),
            [4, 7, 2, 9, 6, 3, 1]);
        yield return (
            CreateTreeNode(2, 1, 3),
            [2, 3, 1]);
        yield return (
            CreateTreeNode([]),
            []);
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