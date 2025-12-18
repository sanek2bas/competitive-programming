using Top.Interview._150.Common;
using Top.Interview._150.Linked_List;

namespace Linked_List;

public class AddTwoNumbersTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode node1, ListNode node2, int[] answer)
    {
        var solution = new AddTwoNumbers();

        var result = solution.Execute(node1, node2);

        await Assert.That(result.ToArray()).IsEquivalentTo(answer);
    }

    public IEnumerable<(ListNode node1, ListNode node2, int[] answer)> DataSource()
    {
        yield return (
            CreateListNode(2, 4, 3),
            CreateListNode(5, 6, 4),
            new int[] { 7, 0, 8 });
        yield return (
            CreateListNode(9, 9, 9, 9, 9, 9, 9),
            CreateListNode(9, 9, 9, 9),
            new int[] { 8, 9, 9, 9, 0, 0, 0, 1 });
    }

    private ListNode CreateListNode(params int[] numbers)
    {
        return ListNode.Create(numbers);
    }
}