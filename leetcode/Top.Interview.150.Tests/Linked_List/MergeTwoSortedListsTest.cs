using Top.Interview._150.Common;
using Top.Interview._150.Linked_List;

namespace Linked_List;

public class MergeTwoSortedListsTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode<int> node1, ListNode<int> node2, int[] answer)
    {
        var solution = new MergeTwoSortedLists();

        var result = solution.Execute(node1, node2);

        await Assert.That(ListNode<int>.ConvertToArray(result)).IsEquivalentTo(answer);
    }

    public IEnumerable<(ListNode<int>? node1, ListNode<int>? node2, int[] answer)> DataSource()
    {
        yield return (
            ListNode<int>.Create(1, 2, 4),
            ListNode<int>.Create(1, 3, 4),
            new int[] { 1, 1, 2, 3, 4, 4 });
        yield return (
            ListNode<int>.Create(),
            ListNode<int>.Create(0),
            new int[] { 0 });
    }
}