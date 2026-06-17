using Top.Interview._150.Common;
using Top.Interview._150.Linked_List;

namespace Linked_List;

public class RemoveNthNodeFromEndOfListTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(ListNode head, int n, int[] answer)
    {
        var solution = new RemoveNthNodeFromEndOfList();

        var result = solution.Execute(head, n);

        await Assert.That(result.ToArray()).IsEquivalentTo(answer);
    }

    public IEnumerable<(ListNode head, int n, int[] answer)> DataSource()
    {
        yield return (
            CreateListNode(1 ,2, 3, 4, 5),
            2,
            [ 1, 2, 5 ]);

        yield return (
            CreateListNode(1),
            1,
            []);

        yield return (
            CreateListNode(1, 2),
            1,
            [1]);
    }

    private ListNode CreateListNode(params int[] numbers)
    {
        return ListNode.Create(numbers);
    }
}