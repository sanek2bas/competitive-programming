using System.Diagnostics;
using Top.Interview._150.Common;

namespace Common;

public class ListNodeTests
{
    #region Constructor Tests

    [Test]
    public async Task Constructor_WithDefaultValue_CreatesNodeWithDefaultValue()
    {
        var node = new ListNode();
        
        await Assert.That(node.Value).IsEqualTo(-1);
        await Assert.That(node.Next).IsNull();
    }

    [Test]
    public async Task Constructor_WithValue_CreatesNodeWithSpecifiedValue()
    {
        var node = new ListNode(555);
        
        await Assert.That(node.Value).IsEqualTo(555);
        await Assert.That(node.Next).IsNull();
    }

    #endregion

    #region Create Tests

    [Test]
    public async Task CreateLinkedList_WithEmptyArray_ReturnsNull()
    {
        var result = ListNode.Create();

        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task CreateLinkedList_WithSingleElement()
    {
        var result = ListNode.Create(5);
        
        await Assert.That(result).IsNotNull();
        await Assert.That(result.Value).IsEqualTo(5);
        await Assert.That(result.Next).IsNull();
    }

    [Test]
    public async Task CreateLinkedList_WithMultipleElements()
    {
        var start = 0;
        var count = 10;
        var result = ListNode.Create(
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

    #endregion

    #region Creates With Cycle Tests

    [Test]
    public async Task CreateLinkedList_WithCycle_ToFirstNode()
    {
        var start = 1;
        var count = 5;
        var firstIdx = 0;
        var result = ListNode.CreateWithCycle(
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
        
        var result = ListNode.CreateWithCycle(emptyArray, 0);
        
        await Assert.That(result).IsNull();
    }

    #endregion

    #region Convert LinkedList To Array Tests
    
    [Test]
    public async Task ConvertToArray_WithNull_ReturnsEmptyArray()
    {
        ListNode root = null;
        
        var result = ListNode.ConvertToArray(root);
        
        await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task ConvertToArray_WithSingleNode_ReturnsSingleElementArray()
    {
        var val = 42;
        var root = new ListNode(val);

        var result = ListNode.ConvertToArray(root);
        
        await Assert.That(result).HasCount(1);
        await Assert.That(result[0]).IsEqualTo(val);
    }

    [Test]
    public async Task ConvertToArray_WithMultipleNodes_ReturnsCorrectArray()
    {
        var start = 1;
        var count = 5;
        
        var originalArray = Enumerable.Range(start, count).ToArray();
        var root = ListNode.Create(originalArray);
        
        var resultArray = ListNode.ConvertToArray(root);
        
        await Assert.That(resultArray).IsEquivalentTo(originalArray);
    }
    
    #endregion
}