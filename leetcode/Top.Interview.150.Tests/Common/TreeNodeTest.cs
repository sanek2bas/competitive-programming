using Top.Interview._150.Common;

namespace Common;

public class TreeNodeTest
{        
    [Test]
    public async Task Create_SingleNode_WithIntValue()
    {
        int value = 42;
        var node = TreeNode<int>.Create(value);
        
        await Assert.That(node).IsNotNull();
        await Assert.That(node.Value).IsEqualTo(value);
        await Assert.That(node.Left).IsNull();
        await Assert.That(node.Right).IsNull();
    }
        
    [Test]
    public async Task Create_SingleNode_WithStringValue()
    {
        string value = "test";
        var node = TreeNode<string>.Create(value);
        
        await Assert.That(node).IsNotNull();
        await Assert.That(node.Value).IsEqualTo(value);
        await Assert.That(node.Left).IsNull();
        await Assert.That(node.Right).IsNull();
    }

    [Test]
    public async Task Create_WithNullArray_ReturnsNull()
    {
        int?[] values = null;
        
        var result = TreeNode<int?>.Create(values);
        
        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task Create_WithEmptyArray_ReturnsNull()
    {
        int?[] values = Array.Empty<int?>();
        
        var result = TreeNode<int?>.Create(values);
        
        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task Create_WithFirstElementNull_ReturnsNull()
    {
        int?[] values = [null, 1, 2];
        
        var result = TreeNode<int?>.Create(values);
        
        await Assert.That(result).IsNull();
    }

     [Test]
    public async Task Create_WithThreeElements_CreatesCompleteBinaryTree()
    {
        int?[] values = [1, 2, 3];

        var root = TreeNode<int?>.Create(values);
        
        await Assert.That(root).IsNotNull();
        await Assert.That(root.Value).IsEqualTo(1);

        await Assert.That(root.Left).IsNotNull();
        await Assert.That(root.Left.Value).IsEqualTo(2);
        
        await Assert.That(root.Right).IsNotNull();
        await Assert.That(root.Right.Value).IsEqualTo(3);

        await Assert.That(root.Left.Left).IsNull();
        await Assert.That(root.Left.Right).IsNull();
        await Assert.That(root.Right.Left).IsNull();
        await Assert.That(root.Right.Right).IsNull();
    }
        
    [Test]
    public async Task Create_WithNullElements_SkipsNullChildren()
    {
        int?[] values = [1, null, 3, 4, 5];

        var root = TreeNode<int?>.Create(values);
        
        await Assert.That(root).IsNotNull();
        await Assert.That(root.Value).IsEqualTo(1);

        await Assert.That(root.Left).IsNull();

        await Assert.That(root.Right).IsNotNull();
        await Assert.That(root.Right.Value).IsEqualTo(3);

        await Assert.That(root.Right.Left).IsNotNull();
        await Assert.That(root.Right.Left.Value).IsEqualTo(4);

        await Assert.That(root.Right.Right).IsNotNull();
        await Assert.That(root.Right.Right.Value).IsEqualTo(5);
    }
    
    [Test]
    public async Task Create_WithComplexTree_CreatesCorrectStructure()
    {
        int?[] values = [ 1, 2, 3, null, 5, 6, 7, 8, 9 ];
        
        var root = TreeNode<int?>.Create(values);
        
        await Assert.That(root).IsNotNull();
        await Assert.That(root.Value).IsEqualTo(1);
        
        // Level 1
        await Assert.That(root.Left.Value).IsEqualTo(2);
        await Assert.That(root.Right.Value).IsEqualTo(3);
        
        // Level 2
        await Assert.That(root.Left.Left).IsNull();
        await Assert.That(root.Left.Right.Value).IsEqualTo(5);
        await Assert.That(root.Right.Left.Value).IsEqualTo(6);
        await Assert.That(root.Right.Right.Value).IsEqualTo(7);
        
        // Level 3
        await Assert.That(root.Left.Right.Left.Value).IsEqualTo(8);
        await Assert.That(root.Left.Right.Right.Value).IsEqualTo(9);
    }

    [Test]
    public async Task CreateListNode_ThenToArray_ReturnsSameArray()
    {
        int?[] originalArray = [ 1, 2, 3, null, 5, 6, 7, 8, 9 ];
        
        var tree = TreeNode<int?>.Create(originalArray);
        var resultArray = TreeNode<int?>.ToArray(tree);
        
        await Assert.That(resultArray).IsEquivalentTo(originalArray);
    }
}