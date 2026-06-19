using Top.Interview._150.Common;
using Top.Interview._150.Binary_Tree_General;

namespace Binary_Tree_General;

public class BinarySearchTreeIteratorTest
{
    [Test]
    public async Task Solution()
    {
        var node = CreateTreeNode(7, 3, 15, null, null, 9, 20);
        var iterator = new BinarySearchTreeIterator(node);

        await Assert.That(iterator.Next).IsEqualTo(3);
        await Assert.That(iterator.Next).IsEqualTo(7);
        await Assert.That(iterator.HasNext).IsTrue();
        await Assert.That(iterator.Next).IsEqualTo(9);
        await Assert.That(iterator.HasNext).IsTrue();
        await Assert.That(iterator.Next).IsEqualTo(15);
        await Assert.That(iterator.HasNext).IsTrue();
        await Assert.That(iterator.Next).IsEqualTo(20);
        await Assert.That(iterator.HasNext).IsFalse();
    }

    private TreeNode CreateTreeNode(params int?[] values)
    {
        return TreeNode.Create(values);
    }
}