using Top.Interview._150.Common;
using Top.Interview._150.Linked_List;

namespace Linked_List;

public class MergeTwoSortedListsTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode node1, ListNode node2, int[] answer)
    {
        var solution = new MergeTwoSortedLists();

        var result = solution.Execute(node1, node2);

        await Assert.That(result.ToArray()).IsEquivalentTo(answer);
    }

    public IEnumerable<(ListNode node1, ListNode node2, int[] answer)> DataSource()
    {
        yield return (
            CreateListNode(1, 2, 4),
            CreateListNode(1, 3, 4),
            new int[] { 1, 1, 2, 3, 4, 4 });
        yield return (
            CreateListNode(),
            CreateListNode(0),
            new int[] { 0 });
    }

    private ListNode CreateListNode(params int[] numbers)
    {
        return ListNode.Create(numbers);
    }
}