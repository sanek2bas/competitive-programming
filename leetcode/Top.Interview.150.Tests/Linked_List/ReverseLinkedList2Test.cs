using Top.Interview._150.Common;
using Top.Interview._150.Linked_List;

namespace Linked_List;

public class ReverseLinkedList2Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode<int>? head, int left, int right, int[] answer)
    {
        var solution = new ReverseLinkedList2();

        var result = solution.Execute(head, left, right);
        
        await Assert.That(ListNode<int>.ConvertToArray(result)).IsEquivalentTo(answer);
    }

    public IEnumerable<(ListNode<int>? head, int left, int right, int[] answer)> DataSource()
    {
        yield return (
            ListNode<int>.Create(1, 2, 3, 4, 5), 
            2, 4, 
            new int[] { 1, 4, 3, 2, 5 });

        yield return (
            ListNode<int>.Create(5), 
            1, 1, 
            new int[] { 5 });

        yield return (
            ListNode<int>.Create(3, 5), 
            1, 2, 
            new int[] { 5, 3});
    }
}