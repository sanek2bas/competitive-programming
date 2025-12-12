using Top.Interview._150.Common;

namespace Common;

public class ListNodeTests
{
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

    [Test]
    public async Task Map_WithEmptyArray_ReturnsNull()
    {
        var result = ListNode.Map();

        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task Map_WithSingleElement_CreatesSingleNode()
    {
        var result = ListNode.Map(5);
        
        await Assert.That(result).IsNotNull();
        await Assert.That(result.Value).IsEqualTo(5);
        await Assert.That(result.Next).IsNull();
    }

    [Test]
    public async Task Map_WithMultipleElements_CreatesLinkedList()
    {
        var start = 0;
        var count = 10;
        var result = ListNode.Map(
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

    // [Test]
    // public void Map_WithPosZero_CreatesCycleToFirstNode()
    // {
    //     var start = 0;
    //     var count = 10;
    //     var result = ListNode.Map(
    //         [.. Enumerable.Range(start, count)], 0); 
        
    //     // Assert
    //         // Find the last node
    //         var lastNode = result;
    //         while (lastNode.Next != null)
    //             lastNode = lastNode.Next;
            
    //         // Last node should point to the first node
    //         Assert.Same(result, lastNode.Next);
    // }

    //  [Test]
    //     public void Map_WithPosInMiddle_CreatesCycleToMiddleNode()
    //     {
    //         // Arrange
    //         var numbers = new[] { 1, 2, 3, 4, 5 };
            
    //         // Act
    //         var result = ListNode.Map(numbers, 2); // Should point to node with value 3 (0-based index)
            
    //         // Assert
    //         var targetNode = result;
    //         for (int i = 0; i < 2; i++)
    //             targetNode = targetNode.Next;
            
    //         var lastNode = result;
    //         while (lastNode.Next != null)
    //             lastNode = lastNode.Next;
            
    //         Assert.Same(targetNode, lastNode.Next);
    //     }

    //  [Fact]
    //     public void Map_WithPosAtEnd_CreatesCycleToLastNode()
    //     {
    //         // Arrange
    //         var numbers = new[] { 1, 2, 3, 4, 5 };
            
    //         // Act
    //         var result = ListNode.Map(numbers, 4); // Should point to last node
            
    //         // Assert
    //         var targetNode = result;
    //         while (targetNode.Next != null)
    //             targetNode = targetNode.Next;
            
    //         var lastNode = result;
    //         while (lastNode.Next != null)
    //             lastNode = lastNode.Next;
            
    //         Assert.Same(targetNode, lastNode.Next);
    //     }

    // [Fact]
    //     public void Map_WithEmptyArrayAndPos_ReturnsNull()
    //     {
    //         // Arrange
    //         var emptyArray = new int[0];
            
    //         // Act
    //         var result = ListNode.Map(emptyArray, 0);
            
    //         // Assert
    //         Assert.Null(result);
    //     }

    // #region ToArray Tests
    //     [Fact]
    //     public void ToArray_WithNull_ReturnsEmptyArray()
    //     {
    //         // Arrange
    //         ListNode root = null;
            
    //         // Act
    //         var result = ListNode.ToArray(root);
            
    //         // Assert
    //         Assert.Empty(result);
    //     }

    //     [Fact]
    //     public void ToArray_WithSingleNode_ReturnsSingleElementArray()
    //     {
    //         // Arrange
    //         var root = new ListNode(42);
            
    //         // Act
    //         var result = ListNode.ToArray(root);
            
    //         // Assert
    //         Assert.Single(result);
    //         Assert.Equal(42, result[0]);
    //     }

    //     [Fact]
    //     public void ToArray_WithMultipleNodes_ReturnsCorrectArray()
    //     {
    //         // Arrange
    //         var root = ListNode.Map(1, 2, 3, 4, 5);
            
    //         // Act
    //         var result = ListNode.ToArray(root);
            
    //         // Assert
    //         Assert.Equal(new[] { 1, 2, 3, 4, 5 }, result);
    //     }

    //     [Fact]
    //     public void ToArray_WithCyclicList_ThrowsStackOverflow()
    //     {
    //         // Note: This test expects an infinite loop/stack overflow
    //         // In practice, you might want to add cycle detection to ToArray method
    //         // Arrange
    //         var numbers = new[] { 1, 2, 3 };
    //         var root = ListNode.Map(numbers, 1); // Creates a cycle
            
    //         // Act & Assert
    //         // This will cause infinite loop - we should handle it differently
    //         // For now, we'll skip this test or expect it to run indefinitely
    //         // var result = ListNode.ToArray(root); // This will never complete
    //     }
    // #endregion

       
        #region Integration Tests
        // [Fact]
        // public void MapAndToArray_RoundTrip_PreservesValues()
        // {
        //     // Arrange
        //     var originalArray = new[] { 10, 20, 30, 40, 50 };
            
        //     // Act
        //     var list = ListNode.Map(originalArray);
        //     var resultArray = ListNode.ToArray(list);
            
        //     // Assert
        //     Assert.Equal(originalArray, resultArray);
        // }

        // [Fact]
        // public void Map_WithArrayAndNegativePos_CreatesNonCyclicList()
        // {
        //     // Arrange
        //     var numbers = new[] { 1, 2, 3 };
            
        //     // Act
        //     var result = ListNode.Map(numbers, -1);
            
        //     // Assert
        //     var array = ListNode.ToArray(result);
        //     Assert.Equal(new[] { 1, 2, 3 }, array);
        // }
        #endregion
       



#region Edge Cases
        // [Fact]
        // public void Map_WithLargeArray_HandlesManyElements()
        // {
        //     // Arrange
        //     var largeArray = new int[1000];
        //     for (int i = 0; i < 1000; i++)
        //         largeArray[i] = i;
            
        //     // Act
        //     var result = ListNode.Map(largeArray);
            
        //     // Assert
        //     var current = result;
        //     for (int i = 0; i < 1000; i++)
        //     {
        //         Assert.NotNull(current);
        //         Assert.Equal(i, current.Value);
        //         current = current.Next;
        //     }
        //     Assert.Null(current);
        // }

        // [Fact]
        // public void Map_WithSameValueArray_HandlesDuplicateValues()
        // {
        //     // Arrange & Act
        //     var result = ListNode.Map(5, 5, 5, 5);
            
        //     // Assert
        //     var current = result;
        //     for (int i = 0; i < 4; i++)
        //     {
        //         Assert.NotNull(current);
        //         Assert.Equal(5, current.Value);
        //         current = current.Next;
        //     }
        //     Assert.Null(current);
        // }

        // [Fact]
        // public void ToArray_WithMaximumValues_HandlesAllValues()
        // {
        //     // Arrange
        //     var root = ListNode.Map(int.MinValue, 0, int.MaxValue);
            
        //     // Act
        //     var result = ListNode.ToArray(root);
            
        //     // Assert
        //     Assert.Equal(new[] { int.MinValue, 0, int.MaxValue }, result);
        // }
        #endregion

}