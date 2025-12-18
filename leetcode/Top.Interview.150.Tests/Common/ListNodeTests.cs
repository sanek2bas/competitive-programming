using Top.Interview._150.Common;

namespace Common;

public class ListNodeTests
{
    [Test]
    public async Task Constructor_WithDefaultValue_CreatesNodeWithDefaultValue()
    {
        var node = CreateListNode(0);
        
        await Assert.That(node).IsNotNull();
        await Assert.That(node.Value).IsEqualTo(0);
        await Assert.That(node.Next).IsNull();
    }

    [Test]
    public async Task Constructor_WithValue_CreatesNodeWithSpecifiedValue()
    {
        var node = CreateListNode(555);
        
        await Assert.That(node).IsNotNull();
        await Assert.That(node.Value).IsEqualTo(555);
        await Assert.That(node.Next).IsNull();
    }

    [Test]
    public async Task CreateLinkedList_WithEmptyArray_ReturnsNull()
    {
        var result = CreateListNode();

        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task CreateLinkedList_WithSingleElement()
    {
        var result = CreateListNode(5);
        
        await Assert.That(result).IsNotNull();
        await Assert.That(result.Value).IsEqualTo(5);
        await Assert.That(result.Next).IsNull();
    }

    [Test]
    public async Task CreateLinkedList_WithMultipleElements()
    {
        var start = 0;
        var count = 10;
        var result = CreateListNode(
            [.. Enumerable.Range(start, count)]); 
        
        var current = result;
        for (int i = start; i < count; i++)
        {
            await Assert.That(current).IsNotNull();
            await Assert.That(current.Value).IsEqualTo(i);
            current = current.Next;
        }
        await Assert.That(current).IsNull();
    }

    [Test]
    public async Task CreateLinkedList_WithCycle_ToFirstNode()
    {
        var start = 1;
        var count = 5;
        var firstIdx = 0;
        var result = CreateListNodeWithCycle(
            [.. Enumerable.Range(start, count)], firstIdx); 
        
        var lastNode = result;
        for(int i = 1; i < count; i++)
            lastNode = lastNode.Next;
        
        await Assert.That(lastNode).IsNotNull();
        await Assert.That(result)
            .IsSameReferenceAs(lastNode.Next);
    }

    [Test]
    public async Task CreateLinkedList_WithCycle_ByEmptyArrayAndPos()
    {
        var emptyArray = new int[0];
        
        var result = CreateListNodeWithCycle(emptyArray, 0);
        
        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task ConvertToArray_WithSingleNode_ReturnsSingleElementArray()
    {
        var val = 42;
        var root = CreateListNode(val);

        var result = root.ToArray();
        
        await Assert.That(result).HasCount(1);
        await Assert.That(result[0]).IsEqualTo(val);
    }

    [Test]
    public async Task ConvertToArray_WithMultipleNodes_ReturnsCorrectArray()
    {
        var start = 1;
        var count = 5;
        
        var originalArray = Enumerable.Range(start, count).ToArray();
        var root = CreateListNode(originalArray);
        
        var resultArray = root.ToArray();
        
        await Assert.That(resultArray).IsEquivalentTo(originalArray);
    }

    private ListNode CreateListNode(params int[] numbers)
    {
        return ListNode.Create(numbers);
    }

    private ListNode CreateListNodeWithCycle(int[] numbers, int position)
    {
        return ListNode.CreateWithCycle(numbers, position);
    }
}