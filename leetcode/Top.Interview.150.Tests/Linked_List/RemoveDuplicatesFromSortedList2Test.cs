using Top.Interview._150.Common;
using Top.Interview._150.Linked_List;

namespace Linked_List;

public class RemoveDuplicatesFromSortedList2Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode<int> head, int[] answer)
    {
        var solution = new RemoveDuplicatesFromSortedList2();

        var result = solution.Execute(head);

        await Assert.That(ListNode<int>.ConvertToArray(result)).IsEquivalentTo(answer);
    }

    public IEnumerable<(ListNode<int>? result, int[] answer)> DataSource()
    {
        yield return (
            ListNode<int>.Create(1, 2, 3, 3, 4, 4, 5), 
            new int[] { 1, 2, 5 });
        yield return (
            ListNode<int>.Create(1, 1, 1, 2, 3),
            new int[] { 2, 3});
    }
}