using Top.Interview._150.Common;
using Top.Interview._150.Linked_List;

namespace Linked_List;

public class AddTwoNumbersTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode<int> node1, ListNode<int> node2, int[] answer)
    {
        var solution = new AddTwoNumbers();

        var result = solution.Execute(node1, node2);

        await Assert.That(ListNode<int>.ConvertToArray(result)).IsEquivalentTo(answer);
    }

    public IEnumerable<(ListNode<int>? node1, ListNode<int>? node2, int[] answer)> DataSource()
    {
        yield return (
            ListNode<int>.Create(2, 4, 3),
            ListNode<int>.Create(5, 6, 4),
            new int[] { 7, 0, 8 });
        yield return (
            ListNode<int>.Create(9, 9, 9, 9, 9, 9, 9),
            ListNode<int>.Create(9, 9, 9, 9),
            new int[] { 8, 9, 9, 9, 0, 0, 0, 1 });
    }
}