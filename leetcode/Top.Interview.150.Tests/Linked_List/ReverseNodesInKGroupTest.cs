using Top.Interview._150.Common;
using Top.Interview._150.Linked_List;

namespace Linked_List;

public class ReverseNodesInKGroupTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode head, int k, int[] answer)
    {
        var solution = new ReverseNodesInKGroup();

        var result = solution.Execute(head, k);

        await Assert.That(ListNode.ConvertToArray(result))
                    .IsEquivalentTo(answer);
    }

    public IEnumerable<(ListNode head, int k, int[] answer)> DataSource()
    {
        yield return (
            CreateListNode(1, 2, 3, 4, 5),
            2,
            [ 2, 1, 4, 3, 5 ]);

        yield return (
            CreateListNode(1, 2, 3, 4, 5),
            3,
            [3, 2, 1, 4, 5]);
    }

    private ListNode CreateListNode(params int[] numbers)
    {
        return ListNode.Create(numbers);
    }
}