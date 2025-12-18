using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_General;

namespace Binary_Tree_General;

public class FlattenBinaryTreeToLinkedListTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(TreeNode root, int?[] answer)
    {
        var solution = new FlattenBinaryTreeToLinkedList();

        solution.Execute(root);
        
        await Assert.That(ConvertToArray(root)).IsEquivalentTo(answer);
    }

    public IEnumerable<(TreeNode root, int?[] answer)> DataSource()
    {
        yield return (
            CreateTreeNode(1, 2, 5, 3, 4, null, 6),
            [ 1, null, 2, null, 3, null, 4, null, 5, null, 6 ]);
        yield return (
            CreateTreeNode(), 
            []);
        yield return (
            CreateTreeNode(0),
            [0]);
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