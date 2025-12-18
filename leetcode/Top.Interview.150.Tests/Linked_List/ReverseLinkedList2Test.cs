using Top.Interview._150.Common;
using Top.Interview._150.Linked_List;

namespace Linked_List;

public class ReverseLinkedList2Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode head, int left, int right, int[] answer)
    {
        var solution = new ReverseLinkedList2();

        var result = solution.Execute(head, left, right);
        
        await Assert.That(result.ToArray()).IsEquivalentTo(answer);
    }

    public IEnumerable<(ListNode head, int left, int right, int[] answer)> DataSource()
    {
        yield return (
            CreateListNode(1, 2, 3, 4, 5), 
            2, 4, 
            new int[] { 1, 4, 3, 2, 5 });

        yield return (
            CreateListNode(5), 
            1, 1, 
            new int[] { 5 });

        yield return (
            CreateListNode(3, 5), 
            1, 2, 
            new int[] { 5, 3});
    }

    private ListNode CreateListNode(params int[] numbers)
    {
        return ListNode.Create(numbers);
    }
}